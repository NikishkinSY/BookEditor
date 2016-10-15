using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookEditor_Repository.Interfaces;
using Microsoft.Extensions.Logging;
using BookEditor_Web.Models;
using BookEditor_Web.Modules;
using AutoMapper;
using BookEditor_Model.Entities;

namespace BookEditor_Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookController> _logger;

        public BookController(
            IBookRepository bookRepository,
            ILogger<BookController> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Title = "Books";
            return View();
        }
        
        [HttpGet]
        public async Task<IEnumerable<BookViewModel>> Get()
        {
            return Mapper.Map<IEnumerable<BookViewModel>>(await _bookRepository.GetAllAsync());
        }

        [HttpPost]
        public async Task<int> Add([FromBody]BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                var _book = Mapper.Map<Book>(book);
                _bookRepository.Add(_book);
                await _bookRepository.CommitAsync();
                return _book.Id;
            }
            else
                return -1;
            
        }

        [HttpPost]
        public async Task<bool> Edit([FromBody]BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.Edit(Mapper.Map<Book>(book));
                await _bookRepository.CommitAsync();
                return true;
            }
            else
                return false;
        }

        [HttpPost]
        public async Task Delete(int id)
        {
            _bookRepository.Delete(id);
            await _bookRepository.CommitAsync();
        }
    }
}
