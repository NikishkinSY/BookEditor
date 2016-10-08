using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookEditor_Model;
using BookEditor_Model.Context;
using BookEditor_Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using BookEditor_Model.Entities;

namespace BookEditor_Repository.Repositories
{
    public class BookRepository: GenericRepository<DbContext, Book>, IBookRepository
    {
        public BookRepository(BookEditorContext context)
            : base(context)
        {
        }

        public void AddAuthorToBook(Book book, Author author)
        {
            ((BookEditorContext)_context).BookAuthor.Add(new BookAuthor(book, author));
        }
        
    }
}
