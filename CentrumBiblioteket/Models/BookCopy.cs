using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumBiblioteket.Models
{
    public class BookCopy
    {
        /*Since the cardinal relationship between BookCopy and BookEdition is one-to-one, a junktion 
        table is not needed to associate each unique BookCopy with a corresponding BookEdition */

        public int BookCopyId { get; set; }

        //Added attributes for input validation. 
        [Required]
        [RegularExpression(@"[a-z]{2,}", ErrorMessage = "Please input {yes} or {no}.")]
        [StringLength(3, ErrorMessage = "Please input {yes} or {no}.", MinimumLength = 2)]
        public string Available { get; set; }

        [Required]
        //Nav prop for configuring relationship with BookEdition: Each bookCopy has one BookEdition (one-to-one).
        public int BookEditionId { get; set; }
        public BookEdition BookEdition { get; set; }

        //collection prop used to establish one-to-many relationship with BookLoan.
        public virtual ICollection<BookLoan> BookLoans { get; set; }

    }
}
