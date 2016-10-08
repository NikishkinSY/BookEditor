using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookEditor_Model;
using BookEditor_Web.Models;
using BookEditor_Model.Entities;

namespace BookEditor_Web.Modules
{
    public static class Automapper
    {
        public static Book Map(BookViewModel bookViewModel)
        {
            var book = new Book()
            {
                Id = bookViewModel.Id,
                Header = bookViewModel.Header,
                PageCount = bookViewModel.PageCount,
                PublishingHouseName = bookViewModel.PublishingHouseName,
                PublishYear = bookViewModel.PublishYear,
                ISBN = bookViewModel.ISBN,
                Image = bookViewModel.Image
            };

            book.BookAuthors = bookViewModel.Authors?.Select(x => new BookAuthor(book, Map(x))).ToList();

            return book;
        }

        public static BookViewModel Map(Book book)
        {
            var bookViewModel = new BookViewModel()
            {
                Id = book.Id,
                Header = book.Header,
                PageCount = book.PageCount,
                PublishingHouseName = book.PublishingHouseName,
                PublishYear = book.PublishYear,
                ISBN = book.ISBN,
                Image = book.Image,
            };
            
            bookViewModel.Authors = book.BookAuthors?.Select(x => Map(x.Author));
            return bookViewModel;
        }

        public static Author Map(AuthorViewModel authorViewModel)
        {
            return new Author()
            {
                Id = authorViewModel.Id,
                FirstName = authorViewModel.FirstName,
                SecondName = authorViewModel.SecondName
            };
        }

        public static AuthorViewModel Map(Author author)
        {
            return new AuthorViewModel()
            {
                Id = author.Id,
                FirstName = author.FirstName,
                SecondName = author.SecondName
            };
        }


        public static void Configurate()
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<Book, BookViewModel>());
            //.ForMember(dest => dest.Dic, opt => opt.ResolveUsing<DictionaryResolver>());

            //Mapper.Initialize(cfg => cfg.CreateMap<BookViewModel, Book>());

            //Mapper.Initialize(cfg => cfg.CreateMap<Author, AuthorViewModel>()
            //    .ForSourceMember(x => x.BookAuthors, opt => opt.Ignore()));
            //Mapper.Initialize(cfg => cfg.CreateMap<AuthorViewModel, Author>());
            //Mapper.AssertConfigurationIsValid();
        }
    }

        //public class CustomResolver : AutoMapper.IValueResolver
        //{
        //public TDestMember Resolve(TSource source, TDestination destination, TDestMember destMember, ResolutionContext context);
        //protected override int ResolveCore(string source)
        //{
        //    return 0;
        //}
        //}
}
