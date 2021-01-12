using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumBiblioteket.Models
{
    public class Author
    {
        /*Primary key. '[Key]' attribute is redundant as standard naming 
        convention enables Entity Framework to identify property as primary key.
        which can not be null and must be a unique value*/
        public int AuthorId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        /*Utilised by 'OnModelCreating(ModelBuilder modelBuilder)' method, in DbContext, which modifies
        key constraint, modality and cardinal relationship*/
        public virtual ICollection<BookEdition_Author> BookEdition_Authors { get; set; }
    }
}
