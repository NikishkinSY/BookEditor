using System.Collections.Generic;
using System.Linq;
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

        public override Book GetById(int id)
        {
            return ((BookEditorContext)_context).Books
                .Include(book => book.BookAuthors).First(x => x.Id == id);
        }

        public override IQueryable<Book> GetAll()
        {
            return ((BookEditorContext)_context).Books
                .Include(book => book.BookAuthors)
                .ThenInclude(bookAuthor => bookAuthor.Author);
        }
        
        public override void Edit(Book entity)
        {
            //EF7 (Core) has some problems with many-to-many relationships
            var dbBook = GetById(entity.Id);
            var bindsDB = dbBook.BookAuthors != null ? dbBook.BookAuthors : new List<BookAuthor>();

            var addBinds = entity.BookAuthors.Except(bindsDB).ToList();
            var removeBinds = bindsDB.Except(entity.BookAuthors).ToList();

            removeBinds.ForEach(x => dbBook.BookAuthors.Remove(x));
            foreach (var bind in addBinds)
            {
                // attach courses because it came from client as detached state in disconnected scenario
                if (_context.Entry(bind).State == EntityState.Deleted)
                    ((BookEditorContext)_context).BookAuthors.Attach(bind);

                // add course in existing student's course collection
                dbBook.BookAuthors.Add(bind);
            }

            dbBook.Header = entity.Header;
            dbBook.PageCount = entity.PageCount;
            dbBook.PublishingHouseName = entity.PublishingHouseName;
            dbBook.PublishYear = entity.PublishYear;
            dbBook.ISBN = entity.ISBN;
            dbBook.Image = entity.Image;

            _context.Entry(dbBook).State = EntityState.Modified;
        }
    }
}
