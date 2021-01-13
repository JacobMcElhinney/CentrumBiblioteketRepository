﻿using System;
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
    public class LibraryCardsController : ControllerBase
    {
        private readonly CentrumBiblioteketDbContext _context;

        public LibraryCardsController(CentrumBiblioteketDbContext context)
        {
            _context = context;
        }

        // GET: api/LibraryCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibraryCard>>> GetLibraryCards()
        {
            return await _context.LibraryCards.ToListAsync();
        }

        // GET: api/LibraryCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LibraryCard>> GetLibraryCard(int id)
        {
            var libraryCard = await _context.LibraryCards.FindAsync(id);

            if (libraryCard == null)
            {
                return NotFound();
            }

            return libraryCard;
        }

        // PUT: api/LibraryCards/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibraryCard(int id, LibraryCard libraryCard)
        {
            if (id != libraryCard.LibraryCardId)
            {
                return BadRequest();
            }

            _context.Entry(libraryCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibraryCardExists(id))
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

        // POST: api/LibraryCards
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LibraryCard>> PostLibraryCard(LibraryCard libraryCard)
        {
            _context.LibraryCards.Add(libraryCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibraryCard", new { id = libraryCard.LibraryCardId }, libraryCard);
        }

        // DELETE: api/LibraryCards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LibraryCard>> DeleteLibraryCard(int id)
        {
            var libraryCard = await _context.LibraryCards.FindAsync(id);
            if (libraryCard == null)
            {
                return NotFound();
            }

            _context.LibraryCards.Remove(libraryCard);
            await _context.SaveChangesAsync();

            return libraryCard;
        }

        private bool LibraryCardExists(int id)
        {
            return _context.LibraryCards.Any(e => e.LibraryCardId == id);
        }
    }
}
