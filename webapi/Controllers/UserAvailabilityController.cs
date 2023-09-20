using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAvailabilityController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public UserAvailabilityController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> UserAvailability(string id)
        {
            var result = await _context.UserAvailabilities.FirstOrDefaultAsync(u => u.ApiUserId == id);
            if(result == null)
                
            {
                bool availableTimes = false;
                object data = new { availableTimes };
            return data;
            }
            else
            {
                bool availableTimes = true;

                return new { availableTimes, result };
            }
            
        }
        [HttpPost]
        public async Task<ActionResult<UserAvailability>> PostData(UserAvailability obj)
        {
            _context.UserAvailabilities.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostData), new { id = obj.Id }, obj);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> putData(int id, UserAvailability app)
        {
            if (id != app.Id)
            {
                return BadRequest();
            }

            _context.Entry(app).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.UserAvailabilities.Any(e => e.Id == id);
        }

    }
}
