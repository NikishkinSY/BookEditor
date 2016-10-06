using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookEditor_Model;
using BookEditor_Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookEditor_Repository.Repositories
{
    public class BookRepository: GenericRepository<DbContext, Book>, IBookRepository
    {
        public BookRepository(DbContext context)
            :base(context)
        {
        }
    }
}
