using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookEditor_Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using BookEditor_Model.Context;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Diagnostics;

namespace BookEditor_Web.Controllers
{
    public class BookController : Controller
    {

        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookController> _logger;

        public BookController(
            IAuthorRepository authorRepository,
            IBookRepository bookRepository, 
            ILogger<BookController> logger)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _logger = logger;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            
            return View();
        }

        
    }
}
