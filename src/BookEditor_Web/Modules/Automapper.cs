using System;
using System.Linq;
using BookEditor_Web.Models;
using BookEditor_Model.Entities;
using AutoMapper;
using System.Collections.Generic;

namespace BookEditor_Web.Modules
{
    public static class Automapper
    {
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
                foreach (var item in source.BookAuthors.Select(x => new AuthorViewModel() { Id = x.AuthorId, FirstName = x.Author.FirstName, SecondName = x.Author.SecondName }))
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
                foreach (var item in source.Authors.Select(x => new BookAuthor() { Book= destination, BookId = source.Id, AuthorId = x.Id }))
                    destMember.Add(item);
            return destMember;
        }
    }
}
