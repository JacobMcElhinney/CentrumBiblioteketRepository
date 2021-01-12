using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumBiblioteket.Models
{
    public class LibraryCard
    {

        public int LibraryCardId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        //Version 1.1: Added Customer Phone number.
        [Required]
        public int PhoneNumber { get; set; }

        public virtual ICollection<BookLoan> BookLoans { get; set; }
    }
}
