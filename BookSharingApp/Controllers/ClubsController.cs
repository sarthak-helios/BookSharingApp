using System.Security.Claims;
using BookSharingApp.Data;
using BookSharingApp.DTOs;
using BookSharingApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookSharingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubsController(AppDbContext _context) : ControllerBase
    {
        [HttpGet("")]
        [Authorize]
        public async Task<IActionResult> GetAll(int page = 1, int results = 5, string? search = null)
        {
            try
            {
                var role = User.FindFirst("Role")?.Value;
                if (role != "admin")
                {
                    return Unauthorized(new { msg = "You are not authorized to perform this action." });
                }
                var clubs = await _context.Clubs
                                          .OrderByDescending(x => x.IsActive)
                                          .ThenBy(c => c.Name)
                                          .Where(q => search == null || q.Name.Contains(search) || q.Location.Contains(search))
                                          .Skip((page - 1) * results)
                                          .Take(results)
                                          .Select(x => new
                                          {
                                              x.Id,
                                              x.Name,
                                              x.Logo,
                                              x.IsActive,
                                              x.Location,
                                              x.CreatedAt,
                                              ClubAdmins = _context.ClubUsers
                                                                   .Where(cu => cu.ClubId == x.Id && cu.Role == "clubadmin")
                                                                   .Select(cu => new { cu.User.Name }).ToList(),
                                              TotalMembers = _context.ClubUsers
                                                                     .Count(cu => cu.ClubId == x.Id)
                                          })
                                          .ToListAsync();
                var total = await _context.Clubs
                                          .Where(q => search == null || q.Name.Contains(search) || q.Location.Contains(search)).CountAsync();
                return Ok(new
                {
                    msg = "Clubs loaded successfully.",
                    clubs,
                    totalPages = Math.Ceiling((double)total / results),
                    page,
                    total
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = ex.Message });
            }
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddClub([FromBody] AddClubsDTO club)
        {
            try
            {
                var role = User.FindFirst("Role")?.Value;
                if (role != "admin")
                {
                    return Unauthorized(new { msg = "You are not authorized to perform this action." });
                }

                var newClub = new ClubModel
                {
                    Name = club.Name,
                    Logo = club.Logo,
                    Location = club.Location,
                    IsActive = club.IsActive,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                var data = await _context.Clubs.AddAsync(newClub);
                await _context.SaveChangesAsync();

                return Ok(new { club = data.Entity, msg = "Club added successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeActivateClub([FromRoute] int id)
        {
            try
            {
                var role = User.FindFirst("Role")?.Value;
                if (role != "admin")
                {
                    return Unauthorized(new { msg = "You are not authorized to perform this action." });
                }
                var club = await _context.Clubs.SingleOrDefaultAsync(c => c.Id == id);
                if (club?.Id != id)
                {
                    return BadRequest(new { msg = "Error finding club with the provided Id." });
                }
                club.IsActive = !club.IsActive;
                await _context.SaveChangesAsync();
                return Ok(new { msg = "Club Activation changed Successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetClubByID([FromRoute] int id)
        {
            try
            {
                var role = User.FindFirst("Role")?.Value;
                if (role != "admin")
                {
                    return Unauthorized(new { msg = "You are not authorized to perform this action." });
                }
                var club = await _context.Clubs.SingleOrDefaultAsync(x => x.Id == id);
                if (club == null)
                {
                    return NotFound(new { msg = "Club not found." });
                }
                return Ok(new { club, msg = "Club loaded successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateClubByID([FromRoute] int id, [FromBody] AddClubsDTO data)
        {
            try
            {
                var role = User.FindFirst("Role")?.Value;
                if (role != "admin")
                {
                    return Unauthorized(new { msg = "You are not authorized to perform this action." });
                }
                var club = await _context.Clubs.SingleOrDefaultAsync(x => x.Id == id);
                if (club == null)
                {
                    return NotFound(new { msg = "Club not found." });
                }
                club.UpdatedAt = DateTime.UtcNow;
                club.Location = data.Location;
                club.Name = data.Name;
                club.Logo = data.Logo;
                await _context.SaveChangesAsync();
                return Ok(new { club, msg = "Club updated successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = ex.Message });
            }
        }

        [HttpGet("get-dd")]
        [Authorize]
        public async Task<IActionResult> GetDDList()
        {
            try
            {
                var role = User.FindFirst("Role")?.Value;
                if (role != "admin")
                {
                    return Unauthorized(new { msg = "You are not authorized to perform this action." });
                }
                var clubs = await _context.Clubs.Where(x => x.IsActive).Select(c => new { c.Id, c.Logo, c.Name }).ToListAsync();
                return Ok(new { msg = "DropDown Data retrieved.", clubs });
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = ex.Message });
            }
        }
    }

}
