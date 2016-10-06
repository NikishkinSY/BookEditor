using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookEditor_Model.Context
{
    public class BookEditorContext: DbContext
    {
        public BookEditorContext(DbContextOptions<BookEditorContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure domain classes using fluent api
            //modelBuilder.Entity<Book>().ToTable("Books");
            //modelBuilder.Entity<Author>().ToTable("Authors");
        }
    }
}
