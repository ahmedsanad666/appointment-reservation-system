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
    public class BookedEventController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;

        private readonly ApplicationDbContext _context;

        public BookedEventController(ApplicationDbContext context , UserManager<ApiUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookedEvents>>> BookedEvents()
        {
            var all = await _context.BookedEvents.Include(q => q.ApiUser).Include(w=>w.Appointment).ToListAsync();

            foreach (var item in all)
            {
                item.GuestData = _userManager.Users.FirstOrDefault(q => q.Id == item.GuestId);
            }
            return all;
        }

   

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookedEvent(int id, BookedEvents app)
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
                if (!EventExists(id))
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

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookedEvents>> PostBookedEvent(BookedEvents BookedEvent)
        {
            _context.BookedEvents.Add(BookedEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostBookedEvent), new { id = BookedEvent.Id }, BookedEvent);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var BookedEv = await _context.BookedEvents.FindAsync(id);
            if (BookedEv == null)
            {
                return NotFound();
            }

            _context.BookedEvents.Remove(BookedEv);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventExists(int id)
        {
            return _context.BookedEvents.Any(e => e.Id == id);
        }
    }
}
