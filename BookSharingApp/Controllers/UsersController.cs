using BookSharingApp.Data;
using BookSharingApp.Models;
using BookSharingApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace BookSharingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(AppDbContext _context) : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllUsers(int page = 1, int results = 5, string? search = null)
        {
            var role = User.FindFirst("Role")?.Value;
            switch (role)
            {
                case "admin":
                    var users = await _context.Users.OrderByDescending(r => r.IsActive).ThenBy(r => r.Name).Where(q => search == null || q.Name.Contains(search) || q.Email.Contains(search))
                                          .Skip((page - 1) * results)
                                          .Take(results)
                                .Select(cu => new
                                {
                                    cu.Id,
                                    cu.Profile,
                                    cu.Name,
                                    cu.Email,
                                    cu.IsActive,
                                    cu.Points,
                                    Mobile = "**" + cu.Mobile.Substring(cu.Mobile.Length - 4),
                                    Clubs = _context.ClubUsers.Where(x => x.UserId == cu.Id && x.Club.IsActive).Select(d => new { d.Role, Club = new { d.Club.Name, d.Club.Logo } }).ToList(),
                                })
                                .ToListAsync();
                    var total = _context.Users.Where(q => search == null || q.Name.Contains(search) || q.Email.Contains(search)).Count();
                    return Ok(new { msg = "Users loaded successfully.", users, total });
                case "clubadmin":
                    var clubIdClaim = User.FindFirst("Id")?.Value.Split('@')[1];
                    if (clubIdClaim == null)
                    {
                        return Unauthorized(new { msg = "Invalid club ID." });
                    }
                    var clubId = int.Parse(clubIdClaim);
                    var clubUsers = await _context.ClubUsers
                                                .Where(cu => cu.ClubId == clubId)
                                                .OrderByDescending(r => r.User != null && r.User.IsActive)
                                                .Where(q => search == null || q.User != null && (q.User.Name.Contains(search) || q.User.Email.Contains(search)))
                                                .Skip((page - 1) * results)
                                                .Take(results)
                                                .Select(cu => new { 
                                                    cu.User.Id, cu.User.Profile, cu.User.Name, cu.User.Email, cu.User.IsActive,
                                                    cu.User.Points, Mobile="**"+cu.User.Mobile.Substring(cu.User.Mobile.Length - 4),cu.Role })
                                                .ToListAsync();
                    var total2 = _context.ClubUsers.Where(c => c.ClubId == clubId).Where(q => search == null || q.User.Name.Contains(search) || q.User.Email.Contains(search)).Count();
                    return Ok(new { msg = "Users loaded successfully.", users = clubUsers, total=total2 });
                default:
                    return Unauthorized(new { msg = "You are not authorized to perform this action." });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RegisterUsers(ClubUsersModel data)
        {
            var role = User.FindFirst("Role")?.Value;
            if (role != "admin" && role != "clubadmin")
            {
                return Unauthorized(new { msg = "You are not authorized to perform this action." });
            }
            if (data.UserId <= 0)
            {
                data.User.Password = data.User.Email.Split('.')[0] + OTPService.GenerateOTP();
                string To = data.User.Email;
                string Sub = "Registered for BookShareApp";
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
                                            <p>Dear {data.User.Name},</p>
                                            <p>Your First Time Password is <span class='otp-code'>{data.User.Password}</span>.</p>
                                            <p>Please Login to your account and change your password.</p>
                                        </div>
                                        <div class='footer'>
                                            <p>Thank you for using our service!</p>
                                        </div>
                                    </div>
                                </body>
                                </html>";
                EmailService.SendEmail(To, Sub, Body);
            }
            if (role == "clubadmin")
            {
                data.ClubId = int.Parse(User.FindFirst("Id")?.Value.Split("@")[1]);
            }
            var user = await _context.ClubUsers.AddAsync(data);
            await _context.SaveChangesAsync();
            return Ok(new { msg = "User created Successfully." });
        }
    }
}
