using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumBiblioteket.Models
{
    public class BookEdition
    {
        public int BookEditionId { get; set; }

        [Required]
        public string BookTitle { get; set; }

        [Required]
        public int YearPublished { get; set; }

        [Required]
        public int Rating { get; set; }

        //ISBN Automatically generated and assigned in controller for the sake of this excercise.
        public string ISBN { get; set; }

        //Used to facilitate cardinal relationship: many-to-many.
        public virtual ICollection<BookEdition_Author> BookEdition_Authors { get; set; }

    }
}
