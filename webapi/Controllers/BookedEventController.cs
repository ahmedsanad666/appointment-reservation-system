using Microsoft.AspNetCore.Http;
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
        private readonly ApplicationDbContext _context;

        public BookedEventController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookedEvents>>> BookedEvents()
        {
            var all = await _context.BookedEvents.ToListAsync();
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
        public async Task<ActionResult<BookedEvents>> PostCourse(BookedEvents BookedEvent)
        {
            _context.BookedEvents.Add(BookedEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = BookedEvent.Id }, BookedEvent);
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
