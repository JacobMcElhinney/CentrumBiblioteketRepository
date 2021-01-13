using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CentrumBiblioteket.Data;
using CentrumBiblioteket.Models;

namespace CentrumBiblioteket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookEditionsController : ControllerBase
    {
        private readonly CentrumBiblioteketDbContext _context;

        public BookEditionsController(CentrumBiblioteketDbContext context)
        {
            _context = context;
        }

        // GET: api/BookEditions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookEdition>>> GetBookEditions()
        {
            return await _context.BookEditions.ToListAsync();
        }

        // GET: api/BookEditions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookEdition>> GetBookEdition(int id)
        {
            var bookEdition = await _context.BookEditions.FindAsync(id);

            if (bookEdition == null)
            {
                return NotFound();
            }

            return bookEdition;
        }

        // PUT: api/BookEditions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookEdition(int id, BookEdition bookEdition)
        {
            if (id != bookEdition.BookEditionId)
            {
                return BadRequest();
            }

            _context.Entry(bookEdition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookEditionExists(id))
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

        // POST: api/BookEditions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookEdition>> PostBookEdition(BookEdition bookEdition)
        {
            //ISBN automatically added for the sake of this excercise.
            bookEdition.ISBN = Guid.NewGuid().ToString();

            _context.BookEditions.Add(bookEdition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookEdition", new { id = bookEdition.BookEditionId }, bookEdition);
        }

        // DELETE: api/BookEditions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookEdition>> DeleteBookEdition(int id)
        {
            var bookEdition = await _context.BookEditions.FindAsync(id);
            if (bookEdition == null)
            {
                return NotFound();
            }

            _context.BookEditions.Remove(bookEdition);
            await _context.SaveChangesAsync();

            return bookEdition;
        }

        private bool BookEditionExists(int id)
        {
            return _context.BookEditions.Any(e => e.BookEditionId == id);
        }
    }
}
