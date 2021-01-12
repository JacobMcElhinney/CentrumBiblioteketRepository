﻿// <auto-generated />
using System;
using CentrumBiblioteket.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CentrumBiblioteket.Migrations
{
    [DbContext(typeof(CentrumBiblioteketDbContext))]
    [Migration("20210112174826_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CentrumBiblioteket.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("CentrumBiblioteket.Models.BookCopy", b =>
                {
                    b.Property<int>("BookCopyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Available")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BookEditionId")
                        .HasColumnType("int");

                    b.HasKey("BookCopyId");

                    b.HasIndex("BookEditionId");

                    b.ToTable("BookCopies");
                });

            modelBuilder.Entity("CentrumBiblioteket.Models.BookEdition", b =>
                {
                    b.Property<int>("BookEditionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("YearPublished")
                        .HasColumnType("int");

                    b.HasKey("BookEditionId");

                    b.ToTable("BookEditions");
                });

            modelBuilder.Entity("CentrumBiblioteket.Models.BookEdition_Author", b =>
                {
                    b.Property<int>("BookEditionId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.HasKey("BookEditionId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("BookEdition_Authors");
                });

            modelBuilder.Entity("CentrumBiblioteket.Models.BookLoan", b =>
                {
                    b.Property<int>("BookLoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookCopyId")
                        .HasColumnType("int");

                    b.Property<int>("LibraryCardId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BookLoanId");

                    b.HasIndex("BookCopyId");

                    b.HasIndex("LibraryCardId");

                    b.ToTable("BookLoans");
                });

            modelBuilder.Entity("CentrumBiblioteket.Models.LibraryCard", b =>
                {
                    b.Property<int>("LibraryCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("LibraryCardId");

                    b.ToTable("LibraryCards");
                });

            modelBuilder.Entity("CentrumBiblioteket.Models.BookCopy", b =>
                {
                    b.HasOne("CentrumBiblioteket.Models.BookEdition", "BookEdition")
                        .WithMany()
                        .HasForeignKey("BookEditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CentrumBiblioteket.Models.BookEdition_Author", b =>
                {
                    b.HasOne("CentrumBiblioteket.Models.Author", "Author")
                        .WithMany("BookEdition_Authors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CentrumBiblioteket.Models.BookEdition", "BookEdition")
                        .WithMany("BookEdition_Authors")
                        .HasForeignKey("BookEditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CentrumBiblioteket.Models.BookLoan", b =>
                {
                    b.HasOne("CentrumBiblioteket.Models.BookCopy", "BookCopy")
                        .WithMany("BookLoans")
                        .HasForeignKey("BookCopyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CentrumBiblioteket.Models.LibraryCard", "LibraryCard")
                        .WithMany("BookLoans")
                        .HasForeignKey("LibraryCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
