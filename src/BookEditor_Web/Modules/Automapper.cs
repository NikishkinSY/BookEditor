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
        public static void Configurate()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Book, BookViewModel>());
            Mapper.Initialize(cfg => cfg.CreateMap<BookViewModel, Book>());

            Mapper.Initialize(cfg => cfg.CreateMap<Author, AuthorViewModel>());
            Mapper.Initialize(cfg => cfg.CreateMap<AuthorViewModel, Author>());
        }
    }
}
