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
    public class BookLoansOverdueController : Controller
    {
        private readonly CentrumBiblioteketDbContext _context;

        public BookLoansOverdueController(CentrumBiblioteketDbContext context)
        {
            _context = context;
        }

        // GET: BookLoansOverdue
        public async Task<IActionResult> Index()
        {
            /*BookLoans are Overdue +30 days past LoanDate. The 'Where(Expression)' filters out BookLoans that are not overdue as of 'DateTime.Now. 
             Related data is then included using LINQ: '.ThenInclude() method. This is possible thanks to the navigation property added in the BookCopy 
            class/model - see futher comments in said class */
            var centrumBiblioteketDbContext = _context.BookLoans.Where(bl => bl.LoanDate.AddDays(30) < DateTime.Now)
                .Include(b => b.BookCopy)
                .ThenInclude(b => b.BookEdition)
                .Include(b => b.LibraryCard);

            //Validates the modelstate to confirm if data binding was successful. Returns error message if values failed to bind to the model.
            if (!ModelState.IsValid)
            {
                return BadRequest("Informationen gick ej att hämta. Vänligen kontakta administratör/it-ansvarig");
            }

            return View(await centrumBiblioteketDbContext.ToListAsync());
        }

        // GET: BookLoansOverdue/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookLoan = await _context.BookLoans
                .Include(b => b.BookCopy)
                .Include(b => b.LibraryCard)
                .FirstOrDefaultAsync(m => m.BookLoanId == id);
            if (bookLoan == null)
            {
                return NotFound();
            }

            return View(bookLoan);
        }

        // GET: BookLoansOverdue/Create
        public IActionResult Create()
        {
            ViewData["BookCopyId"] = new SelectList(_context.BookCopies, "BookCopyId", "Available");
            ViewData["LibraryCardId"] = new SelectList(_context.LibraryCards, "LibraryCardId", "FirstName");
            return View();
        }

        // POST: BookLoansOverdue/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookLoanId,LibraryCardId,BookCopyId,LoanDate,ReturnDate")] BookLoan bookLoan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookLoan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookCopyId"] = new SelectList(_context.BookCopies, "BookCopyId", "Available", bookLoan.BookCopyId);
            ViewData["LibraryCardId"] = new SelectList(_context.LibraryCards, "LibraryCardId", "FirstName", bookLoan.LibraryCardId);
            return View(bookLoan);
        }

        // GET: BookLoansOverdue/Edit/5
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
            ViewData["LibraryCardId"] = new SelectList(_context.LibraryCards, "LibraryCardId", "FirstName", bookLoan.LibraryCardId);
            return View(bookLoan);
        }

        // POST: BookLoansOverdue/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookLoanId,LibraryCardId,BookCopyId,LoanDate,ReturnDate")] BookLoan bookLoan)
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
            ViewData["LibraryCardId"] = new SelectList(_context.LibraryCards, "LibraryCardId", "FirstName", bookLoan.LibraryCardId);
            return View(bookLoan);
        }

        // GET: BookLoansOverdue/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookLoan = await _context.BookLoans
                .Include(b => b.BookCopy)
                .Include(b => b.LibraryCard)
                .FirstOrDefaultAsync(m => m.BookLoanId == id);
            if (bookLoan == null)
            {
                return NotFound();
            }

            return View(bookLoan);
        }

        // POST: BookLoansOverdue/Delete/5
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
