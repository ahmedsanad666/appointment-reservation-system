﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }



        // GET: api/all
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> AllAppointments()
        {
            var all = await _context.Appointments.Include(q => q.ApiUser).ToListAsync();
            return all;
        }

        // GET: api/Courses/id
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAllAppointments(string id)
        {
                var all = await _context.Appointments.Where(q => q.ApiUserId == id).ToListAsync();
            return all;
        }



        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Appointment app)
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

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostApp(List<Appointment> apps)
        {
            var result = new List<Appointment>();

            foreach( var  el in apps)
            {
                _context.Appointments.Add(el);
                await _context.SaveChangesAsync();
                result.Add(el);
                
            }
         
           

            return CreatedAtAction(nameof(PostApp),result);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Appointments.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Appointments.Any(e => e.Id == id);
        }
    }
}
