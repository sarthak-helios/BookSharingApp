using System.Security.Claims;
using BookSharingApp.Data;
using BookSharingApp.DTOs;
using BookSharingApp.Models;
using BookSharingApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookSharingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(AppDbContext _context, JWTService _jwt) : ControllerBase
    {
        [HttpPost("get-otp")]
        public async Task<IActionResult> GetLoginOTPUser(GetOTPDTO user)
        {
            try
            {
                var data = await _context.Users
                    .FirstOrDefaultAsync(x => x.Email == user.Email && x.Password == user.Password);

                if (data == null)
                {
                    return Unauthorized(new { msg = "Invalid credentials. Please try again." });
                }

                var clubs = await _context.ClubUsers
                    .Where(x => x.UserId == data.Id && x.Club.IsActive)
                    .Select(x => new { x.Club, x.Role })
                    .ToListAsync();

                if (clubs.Count == 0)
                {
                    return Unauthorized(new { msg = "User not found in any club." });
                }

                string OTP = OTPService.GenerateOTP();
                string To = user.Email;
                string Sub = "OTP for BookShareApp";
                string Body = $@"
                                <!DOCTYPE html>
                                <html lang='en'>
                                <head>
                                    <meta charset='UTF-8'>
                                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                                    <title>OTP Verification</title>
                                    <style>
                                        body {{
                                            font-family: Arial, sans-serif;
                                            margin: 0;
                                            padding: 0;
                                            max-width: 100svw;
                                            background-color: #f4f4f4;
                                        }}
                                        .container {{
                                            width: 100%;
                                            max-width: 600px;
                                            margin: 0 auto;
                                            background-color: #ffffff;
                                            padding: 20px;
                                            border-radius: 8px;
                                            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
                                        }}
                                        .content {{
                                            margin: 20px 0;
                                            font-size: 16px;
                                            line-height: 1.5;
                                        }}
                                        .otp-code {{
                                            font-size: 24px;
                                            font-weight: bold;
                                            color: #333;
                                        }}
                                        .footer {{
                                            text-align: center;
                                            margin-top: 30px;
                                            font-size: 14px;
                                            color: #777;
                                        }}
                                    </style>
                                </head>
                                <body>
                                    <div class='container'>
                                        <div class='content'>
                                            <p>Dear {data.Name},</p>
                                            <p>Your OTP code is <span class='otp-code'>{OTP}</span>.</p>
                                            <p>Please enter this code to verify your account.</p>
                                        </div>
                                        <div class='footer'>
                                            <p>Thank you for using our service!</p>
                                        </div>
                                    </div>
                                </body>
                                </html>";
                data.ResetToken = $"{OTP}@{DateTime.UtcNow.AddMinutes(15)}";
                await _context.SaveChangesAsync();

                EmailService.SendEmail(To, Sub, Body);

                return Ok(new { clubs, msg = "OTP initiated to your email id." });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new { ex.Message });
            }
        }



        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOTPUser(VerifyUserDTO user)
        {
            try
            {
                var data = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email && x.IsActive);

                if (data == null)
                {
                    return Unauthorized(new { msg = "User not Found or is deactivated." });
                }

                string[] OTP = data.ResetToken.Split("@");
                if (OTP[0] != user.OTP)
                {
                    return Unauthorized(new { msg = "Invalid OTP. Please try again." });
                }
                if (DateTime.Parse(OTP[1]) < DateTime.UtcNow)
                {
                    return Unauthorized(new { msg = "OTP expired. Please try again." });
                }
                if (!data.IsActive)
                {
                    return Unauthorized(new { msg = "Your account is deactivated. Please contact support." });
                }
                data.ResetToken = "";
                data.LastLogIn = DateTime.UtcNow;

                var CU = await _context.ClubUsers
                    .Where(x => x.User.Id == data.Id && x.Club.Id == user.ClubId && x.Club.IsActive)
                    .Select(c => new { c.Club, c.User, c.Role })
                    .FirstOrDefaultAsync();

                if (CU == null)
                {
                    return BadRequest(new { msg = "Please Select Valid club." });
                }

                var token = _jwt.IssueToken(data, CU.Club.Id, CU.Role);
                await _context.SaveChangesAsync();
                return Ok(new { token, msg = "Logged In Successfully." });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new { ex.Message });
            }
        }



        [HttpGet("profile")]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            try
            {
                string[] userdata = User.FindFirst("Id").Value.Split("@");
                int userId = int.Parse(userdata[0]);
                int clubId = int.Parse(userdata[1]);
                var data = await _context.ClubUsers
                    .Where(x => x.UserId == userId && x.ClubId == clubId && x.User.IsActive && x.Club.IsActive)
                    .Select(u => new
                    {
                        u.Role,
                        User = new
                        {
                            u.User.Name,
                            u.User.LastLogIn,
                            u.User.Profile,
                            u.User.Points
                        },
                        Club = new
                        {
                            u.Club.Name,
                            u.Club.Location,
                            u.Club.Logo
                        }
                    })
                    .FirstOrDefaultAsync();

                return Ok(new {data,msg="Profile data retrieved successfully."});
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(new { ex.Message });
            }
        }



        [HttpPatch("forgot-password")]
        public async Task<IActionResult> ForgotPass(ForgotPassDTO data)
        {
            try
            {
                var user = await _context.Users.Where(x => x.Email == data.Email).FirstOrDefaultAsync();
                if (user == null) { 
                    return BadRequest(new {msg="Email not found or Account might not exist on this Email."});
                }
                string OTP = OTPService.GenerateOTP();
                user.ResetToken = $"{OTP}@{DateTime.UtcNow.AddMinutes(15)}";
                string To = user.Email;
                string Sub = "OTP for BookShareApp";
                string Body = $@"
                                <!DOCTYPE html>
                                <html lang='en'>
                                <head>
                                    <meta charset='UTF-8'>
                                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                                    <title>Password Reset Verification</title>
                                    <style>
                                        body {{
                                            font-family: Arial, sans-serif;
                                            margin: 0;
                                            padding: 0;
                                            max-width: 100svw;
                                            background-color: #f4f4f4;
                                        }}
                                        .container {{
                                            width: 100%;
                                            max-width: 600px;
                                            margin: 0 auto;
                                            background-color: #ffffff;
                                            padding: 20px;
                                            border-radius: 8px;
                                            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
                                        }}
                                        .content {{
                                            margin: 20px 0;
                                            font-size: 16px;
                                            line-height: 1.5;
                                        }}
                                        .otp-code {{
                                            font-size: 24px;
                                            font-weight: bold;
                                            color: #333;
                                        }}
                                        .footer {{
                                            text-align: center;
                                            margin-top: 30px;
                                            font-size: 14px;
                                            color: #777;
                                        }}
                                    </style>
                                </head>
                                <body>
                                    <div class='container'>
                                        <div class='content'>
                                            <p>Dear {user.Name},</p>
                                            <p>Your OTP code is <span class='otp-code'>{OTP}</span>.</p>
                                            <p>Please enter this code to Proceed.</p>
                                        </div>
                                        <div class='footer'>
                                            <p>Thank you for using our service!</p>
                                        </div>
                                    </div>
                                </body>
                                </html>";
                await _context.SaveChangesAsync();
                EmailService.SendEmail(To, Sub, Body);
                return Ok(new { msg = "OTP sent to your Mail." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = ex.Message });
            }
        }



        [HttpPatch("reset-password")]
        public async Task<IActionResult> ResetPassWord(ResetPassDTO data)
        {
            var user = await _context.Users
                .Where(x => x.Email == data.Email)
                .FirstOrDefaultAsync();

            if (user == null || user.ResetToken == null)
            {
                return BadRequest(new { msg = "Invalid OTP or Email." });
            }

            string[] tokenParts = user.ResetToken.Split("@");
            if (tokenParts[0] != data.OTP)
            {
                return BadRequest(new { msg = "Invalid OTP or Email." });
            }
            if (DateTime.Parse(tokenParts[1]) < DateTime.UtcNow)
            {
                return BadRequest(new { msg = "Otp expired. Please try again." });
            }

            user.Password = data.Password;
            user.ResetToken = null;
            await _context.SaveChangesAsync();

            return Ok(new { msg = "Password reset successfully." });
        }
    }
}
