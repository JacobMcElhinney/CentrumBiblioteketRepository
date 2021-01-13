using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CentrumBiblioteket.Data;
using CentrumBiblioteket.Models;

namespace MVCFunctionality.Controllers
{
    public class BookLoansController : Controller
    {
        private readonly CentrumBiblioteketDbContext _context;

        public BookLoansController(CentrumBiblioteketDbContext context)
        {
            _context = context;
        }

        // GET: BookLoans
        public async Task<IActionResult> Index()
        {
           

            var centrumBiblioteketDbContext = _context.BookLoans.Where(bl => bl.LoanDate.AddDays(30) < DateTime.Now)
                .Include(b => b.BookCopy)
                .Include(b => b.BookEdition)
                .Include(b => b.LibraryCard);
            return View(await centrumBiblioteketDbContext.ToListAsync());
        }

        // GET: BookLoans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookLoan = await _context.BookLoans
                .Include(b => b.BookCopy)
                .Include(b => b.BookEdition)
                .Include(b => b.LibraryCard)
                .FirstOrDefaultAsync(m => m.BookLoanId == id);
            if (bookLoan == null)
            {
                return NotFound();
            }

            return View(bookLoan);
        }

        // GET: BookLoans/Create
        public IActionResult Create()
        {
            ViewData["BookCopyId"] = new SelectList(_context.BookCopies, "BookCopyId", "Available");
            ViewData["BookEditionId"] = new SelectList(_context.BookEditions, "BookEditionId", "BookTitle");
            ViewData["LibraryCardId"] = new SelectList(_context.LibraryCards, "LibraryCardId", "FirstName");
            return View();
        }

        // POST: BookLoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookLoanId,LibraryCardId,BookEditionId,BookCopyId,LoanDate,ReturnDate")] BookLoan bookLoan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookLoan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookCopyId"] = new SelectList(_context.BookCopies, "BookCopyId", "Available", bookLoan.BookCopyId);
            ViewData["BookEditionId"] = new SelectList(_context.BookEditions, "BookEditionId", "BookTitle", bookLoan.BookEditionId);
            ViewData["LibraryCardId"] = new SelectList(_context.LibraryCards, "LibraryCardId", "FirstName", bookLoan.LibraryCardId);
            return View(bookLoan);
        }

        // GET: BookLoans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookLoan = await _context.BookLoans.FindAsync(id);
            if (bookLoan == null)
            {
                return NotFound();
            }
            ViewData["BookCopyId"] = new SelectList(_context.BookCopies, "BookCopyId", "Available", bookLoan.BookCopyId);
            ViewData["BookEditionId"] = new SelectList(_context.BookEditions, "BookEditionId", "BookTitle", bookLoan.BookEditionId);
            ViewData["LibraryCardId"] = new SelectList(_context.LibraryCards, "LibraryCardId", "FirstName", bookLoan.LibraryCardId);
            return View(bookLoan);
        }

        // POST: BookLoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookLoanId,LibraryCardId,BookEditionId,BookCopyId,LoanDate,ReturnDate")] BookLoan bookLoan)
        {
            if (id != bookLoan.BookLoanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookLoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookLoanExists(bookLoan.BookLoanId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookCopyId"] = new SelectList(_context.BookCopies, "BookCopyId", "Available", bookLoan.BookCopyId);
            ViewData["BookEditionId"] = new SelectList(_context.BookEditions, "BookEditionId", "BookTitle", bookLoan.BookEditionId);
            ViewData["LibraryCardId"] = new SelectList(_context.LibraryCards, "LibraryCardId", "FirstName", bookLoan.LibraryCardId);
            return View(bookLoan);
        }

        // GET: BookLoans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookLoan = await _context.BookLoans
                .Include(b => b.BookCopy)
                .Include(b => b.BookEdition)
                .Include(b => b.LibraryCard)
                .FirstOrDefaultAsync(m => m.BookLoanId == id);
            if (bookLoan == null)
            {
                return NotFound();
            }

            return View(bookLoan);
        }

        // POST: BookLoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookLoan = await _context.BookLoans.FindAsync(id);
            _context.BookLoans.Remove(bookLoan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookLoanExists(int id)
        {
            return _context.BookLoans.Any(e => e.BookLoanId == id);
        }
    }
}
