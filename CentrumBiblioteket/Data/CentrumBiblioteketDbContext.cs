using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentrumBiblioteket.Models;

namespace CentrumBiblioteket.Data
{
    public class CentrumBiblioteketDbContext : DbContext
    {


        public CentrumBiblioteketDbContext(DbContextOptions<CentrumBiblioteketDbContext> options) : base(options)
        {
        }


        public DbSet<Author> Authors { get; set; }
        public DbSet<BookEdition> BookEditions { get; set; }
        public DbSet<BookEdition_Author> BookEdition_Authors { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }
        public DbSet<BookLoan> BookLoans { get; set; }
        public DbSet<LibraryCard> LibraryCards { get; set; }
        public DbSet<OverdueBookLoan> OverdueBookLoans { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookEdition_Author>()
                .HasKey(be_a => new { be_a.BookEditionId, be_a.AuthorId });

            modelBuilder.Entity<BookEdition_Author>()
                .HasOne(be_a => be_a.BookEdition)
                .WithMany(be => be.BookEdition_Authors)
                .HasForeignKey(be_a => be_a.BookEditionId);

            modelBuilder.Entity<BookEdition_Author>()
                .HasOne(be_a => be_a.Author)
                .WithMany(a => a.BookEdition_Authors)
                .HasForeignKey(be_a => be_a.AuthorId);

        }
    }
}
