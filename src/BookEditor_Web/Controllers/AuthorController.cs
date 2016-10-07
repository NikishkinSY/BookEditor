using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookEditor_Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace BookEditor_Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(
            IAuthorRepository authorRepository,
            ILogger<AuthorController> logger)
        {
            _authorRepository = authorRepository;
            _logger = logger;
        }

    }
}
