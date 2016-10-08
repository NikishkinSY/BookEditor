using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookEditor_Model;
using BookEditor_Model.Entities;

namespace BookEditor_Repository.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        void AddAuthorToBook(Book book, Author author);
    }
}
