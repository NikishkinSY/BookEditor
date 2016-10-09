﻿using BookEditor_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookEditor_Model.Entities;

namespace BookEditor_Web.Modules
{
    public class SampleData
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        public SampleData(
            IBookRepository bookRepository,
            IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public void Seed()
        {
            if (!_bookRepository.GetAll().Any() &&
                !_authorRepository.GetAll().Any())
            {
                var author1 = new Author() { FirstName = "Федор", SecondName = "Достоевский" };
                var book1 = new Book() { Header = "Преступление и наказание", PageCount = 672, PublishingHouseName = "Дом книг", PublishYear = 1866, ISBN = "978-5-170-90630-7" };
                var book2 = new Book() { Header = "Идиот", PageCount = 640, PublishingHouseName = "Дом книг", PublishYear = 1868, ISBN = "978-5-389-10472-3" };
                book1.BookAuthors = new List<BookAuthor>();
                book1.BookAuthors.Add(new BookAuthor(book1, author1));
                book2.BookAuthors = new List<BookAuthor>();
                book2.BookAuthors.Add(new BookAuthor(book2, author1));
                _authorRepository.Add(author1);
                _bookRepository.Add(book1);
                _bookRepository.Add(book2);


                var author2 = new Author() { FirstName = "Erich", SecondName = "Gamma" };
                var author3 = new Author() { FirstName = "Richard", SecondName = "Helm" };
                var author4 = new Author() { FirstName = "Ralph", SecondName = "Johnson" };
                var author5 = new Author() { FirstName = "John", SecondName = "Vlissides" };
                var book3 = new Book() { Header = "Gang of Four", PageCount = 395, PublishingHouseName = "Addison-Wesley", PublishYear = 1994, ISBN = "0-201-63361-2" };
                book3.BookAuthors = new List<BookAuthor>();
                book3.BookAuthors.Add(new BookAuthor(book3, author2));
                book3.BookAuthors.Add(new BookAuthor(book3, author3));
                book3.BookAuthors.Add(new BookAuthor(book3, author4));
                book3.BookAuthors.Add(new BookAuthor(book3, author5));
                _authorRepository.Add(author2);
                _authorRepository.Add(author3);
                _authorRepository.Add(author4);
                _authorRepository.Add(author5);
                _bookRepository.Add(book3);

                var author6 = new Author() { FirstName = "Jeffrey", SecondName = "Richter" };
                var book4 = new Book() { Header = "CLR via C# (4th Edition)", PageCount = 896, PublishingHouseName = "Microsoft Press", PublishYear = 2012, ISBN = "978-0-735-66745-7" };
                book4.BookAuthors = new List<BookAuthor>();
                book4.BookAuthors.Add(new BookAuthor(book4, author6));
                _authorRepository.Add(author6);
                _bookRepository.Add(book4);


                _bookRepository.Commit();
            }
        }
    }
}
