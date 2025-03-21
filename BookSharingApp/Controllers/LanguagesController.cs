using BookSharingApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookSharingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController(AppDbContext _context) : ControllerBase
    {
        [HttpGet]
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
                var languages = await _context.Languages
                                            .OrderByDescending(x => x.IsActive)
                                            .ThenBy(c => c.Name)
                                            .Where(q => search == null || q.Code.Contains(search) || q.Name.Contains(search))
                                            .Skip((page - 1) * results)
                                            .Take(results)
                                            .ToListAsync();
                var total = await _context.Languages.Where(q => search == null || q.Code.Contains(search) || q.Name.Contains(search)).CountAsync();
                return Ok(new
                {
                    msg = "Languages loaded successfully.",
                    languages,
                    totalPages = Math.Ceiling((double)total / results),
                    page,
                    total
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { msg = ex.Message });
            }
        }
    }
}
