using Microsoft.EntityFrameworkCore;
using BookEditor_Model.Entities;

namespace BookEditor_Model.Context
{
    public class BookEditorContext: DbContext
    {
        private static bool _created = false;
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

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
            modelBuilder.Entity<BookAuthor>().HasKey(x => new { x.BookId, x.AuthorId });

            modelBuilder.Entity<BookAuthor>()
               .HasOne(x => x.Book)
               .WithMany(x => x.BookAuthors)
               .HasForeignKey(x => x.BookId);

            modelBuilder.Entity<BookAuthor>()
               .HasOne(x => x.Author)
               .WithMany(x => x.BookAuthors)
               .HasForeignKey(x => x.AuthorId);

            //Configure domain classes using fluent api
            //modelBuilder.Entity<Book>().ToTable("Books");
            //modelBuilder.Entity<Author>().ToTable("Authors");
        }
    }
}
