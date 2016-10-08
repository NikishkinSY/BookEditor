using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEditor_Model.Entities
{
    //Many-to-Many relationships in Entity Framework Core
    //https://github.com/aspnet/EntityFramework/issues/1368
    public class BookAuthor
    {
        public BookAuthor(Book _book, Author _author)
        {
            Book = _book;
            BookId = _book.Id;
            Author = _author;
            AuthorId = _author.Id;
        }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
