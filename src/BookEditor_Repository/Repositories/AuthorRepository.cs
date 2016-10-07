using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookEditor_Model;
using BookEditor_Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using BookEditor_Model.Context;

namespace BookEditor_Repository.Repositories
{
    public class AuthorRepository: GenericRepository<DbContext, Author>, IAuthorRepository
    {
        public AuthorRepository(BookEditorContext context)
            : base(context)
        {
        }
    }
}
