using BookEditor_Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using BookEditor_Model.Context;
using BookEditor_Model.Entities;

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
