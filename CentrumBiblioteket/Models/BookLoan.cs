using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumBiblioteket.Models
{
    public class BookLoan
    {

        public int BookLoanId { get; set; }


        [Required]
        public int LibraryCardId { get; set; }
        public LibraryCard LibraryCard { get; set; }


        [Required]
        public int BookCopyId { get; set; }
        public BookCopy BookCopy { get; set; }


        //'LoanDate' Automatically set in controller. No user input required.
        public DateTime LoanDate { get; set; }

        /*Is nullable so as to allow for books to be returned at a later date. 
        Regrettably, at this stage, returns are made manually using 
        sql queries in SSMS as no function for Loan/return has beed added to controller yet.*/
        public DateTime? ReturnDate { get; set; }
    }
}
