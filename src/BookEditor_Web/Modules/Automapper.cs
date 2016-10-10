using System;
using System.Linq;
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
                Image = !String.IsNullOrEmpty(bookViewModel.Base64Image.Base64) ? Convert.FromBase64String(bookViewModel.Base64Image.Base64) : null
            };

            book.BookAuthors = bookViewModel.Authors?.Select(x => new BookAuthor(book, x.Id)).ToList();

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
                Base64Image = new Image() { Base64 = book.Image != null ? Convert.ToBase64String(book.Image) : null },
            };

            if (book.BookAuthors != null) bookViewModel.Authors = book.BookAuthors?.Select(x => new AuthorViewModel(x.AuthorId)).ToList();
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
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Book, BookViewModel>()
                    .ForMember(dest => dest.Base64Image, opt => opt.ResolveUsing<ImageResolver>())
                    .ForMember(dest => dest.Authors, opt => opt.ResolveUsing<BookAuthorResolver>());

                cfg.CreateMap<BookViewModel, Book>()
                    .ForMember(dest => dest.Image, opt => opt.ResolveUsing<ImageBackResolver>())
                    .ForMember(dest => dest.BookAuthors, opt => opt.ResolveUsing<BookAuthorBackResolver>());

                cfg.CreateMap<Author, AuthorViewModel>();

                cfg.CreateMap<AuthorViewModel, Author>()
                    .ForMember(x => x.BookAuthors, opt => opt.Ignore());
            });

            Mapper.AssertConfigurationIsValid();
        }
    }

    public class ImageResolver : IValueResolver<Book, BookViewModel, Image>
    {
        public Image Resolve(Book source, BookViewModel destination, Image destMember, ResolutionContext context)
        {
            if (source.Image != null)
                destMember.Base64 = Convert.ToBase64String(source.Image);
            return destMember;
        }
    }
    public class BookAuthorResolver : IValueResolver<Book, BookViewModel, ICollection<AuthorViewModel>>
    {
        public ICollection<AuthorViewModel> Resolve(Book source, BookViewModel destination, ICollection<AuthorViewModel> destMember, ResolutionContext context)
        {
            destMember = new List<AuthorViewModel>();
            if (source.BookAuthors != null)
                foreach (var item in source.BookAuthors.Select(x => new AuthorViewModel(x.AuthorId)))
                    destMember.Add(item);
            return destMember;
        }
    }
    public class ImageBackResolver : IValueResolver<BookViewModel, Book, byte[]>
    {
        public byte[] Resolve(BookViewModel source, Book destination, byte[] destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Base64Image.Base64))
                destMember = Convert.FromBase64String(source.Base64Image.Base64);
            return destMember;
        }
    }
    public class BookAuthorBackResolver : IValueResolver<BookViewModel, Book, ICollection<BookAuthor>>
    {
        public ICollection<BookAuthor> Resolve(BookViewModel source, Book destination, ICollection<BookAuthor> destMember, ResolutionContext context)
        {
            destMember = new List<BookAuthor>();
            if (source.Authors != null)
                foreach (var item in source.Authors.Select(x => new BookAuthor(destination, x.Id)))
                    destMember.Add(item);
            return destMember;
        }
    }
}
