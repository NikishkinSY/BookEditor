using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookEditor_Model.Entities;

namespace BookEditor_Model.Context
{
    public class BookEditorContext: DbContext
    {
        private static bool _created = false;
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public BookEditorContext(DbContextOptions<BookEditorContext> options) : base(options)
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure domain classes using fluent api
            //modelBuilder.Entity<Book>().ToTable("Books");
            //modelBuilder.Entity<Author>().ToTable("Authors");
        }
    }
}
