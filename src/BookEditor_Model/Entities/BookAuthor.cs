﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookEditor_Model.Entities
{
    //Many-to-Many relationships in Entity Framework Core
    //https://github.com/aspnet/EntityFramework/issues/1368
    public class BookAuthor
    {
        public BookAuthor()
        {
        }

        public BookAuthor(Book _book, Author _author)
        {
            Book = _book;
            BookId = _book.Id;
            Author = _author;
            AuthorId = _author.Id;
        }
        public BookAuthor(Book _book, int _authorId)
        {
            Book = _book;
            BookId = _book.Id;
            AuthorId = _authorId;
        }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }

        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        public override bool Equals(Object obj)
        {
            var item = obj as BookAuthor;
            if (item == null)
                return false;

            return BookId == item.BookId && AuthorId == item.AuthorId;
        }

        public override int GetHashCode()
        {
            return BookId.GetHashCode() ^ AuthorId.GetHashCode();
        }
    }
}
