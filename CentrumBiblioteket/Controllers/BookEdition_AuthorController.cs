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
    public class BookEdition_AuthorController : ControllerBase
    {
        private readonly CentrumBiblioteketDbContext _context;

        public BookEdition_AuthorController(CentrumBiblioteketDbContext context)
        {
            _context = context;
        }

        // GET: api/BookEdition_Author
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookEdition_Author>>> GetBookEdition_Authors()
        {
            return await _context.BookEdition_Authors.ToListAsync();
        }

        // GET: api/BookEdition_Author/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookEdition_Author>> GetBookEdition_Author(int id)
        {
            var bookEdition_Author = await _context.BookEdition_Authors.FindAsync(id);

            if (bookEdition_Author == null)
            {
                return NotFound();
            }

            return bookEdition_Author;
        }

        // PUT: api/BookEdition_Author/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookEdition_Author(int id, BookEdition_Author bookEdition_Author)
        {
            if (id != bookEdition_Author.BookEditionId)
            {
                return BadRequest();
            }

            _context.Entry(bookEdition_Author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookEdition_AuthorExists(id))
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

        // POST: api/BookEdition_Author
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookEdition_Author>> PostBookEdition_Author(BookEdition_Author bookEdition_Author)
        {
            _context.BookEdition_Authors.Add(bookEdition_Author);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookEdition_AuthorExists(bookEdition_Author.BookEditionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookEdition_Author", new { id = bookEdition_Author.BookEditionId }, bookEdition_Author);
        }

        // DELETE: api/BookEdition_Author/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookEdition_Author>> DeleteBookEdition_Author(int id)
        {
            var bookEdition_Author = await _context.BookEdition_Authors.FindAsync(id);
            if (bookEdition_Author == null)
            {
                return NotFound();
            }

            _context.BookEdition_Authors.Remove(bookEdition_Author);
            await _context.SaveChangesAsync();

            return bookEdition_Author;
        }

        private bool BookEdition_AuthorExists(int id)
        {
            return _context.BookEdition_Authors.Any(e => e.BookEditionId == id);
        }
    }
}
