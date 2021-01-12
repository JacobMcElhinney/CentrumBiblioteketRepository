using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumBiblioteket.Models
{
    public class BookEdition_Author
    {
        public int BookEditionId { get; set; }
        public BookEdition BookEdition { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
