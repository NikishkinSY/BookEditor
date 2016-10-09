using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookEditor_Repository.Interfaces;
using Microsoft.Extensions.Logging;
using BookEditor_Web.Models;
using BookEditor_Web.Modules;

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
            return await Task.Run(() => { return _bookRepository.GetAll().Select(x => Automapper.Map(x)).ToList(); });
        }

        [HttpPost]
        public async Task<int> Add([FromBody]BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                return await Task.Run(() => {
                    var _book = Automapper.Map(book);
                    _bookRepository.Add(_book);
                    _bookRepository.Commit();
                    return _book.Id;
                });
            }
            else
                return -1;
            
        }

        [HttpPost]
        public async Task<bool> Edit([FromBody]BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                return await Task.Run(() => {
                    _bookRepository.Edit(Automapper.Map(book));
                    _bookRepository.Commit();
                    return true;
                });
            }
            else
                return false;
        }

        [HttpPost]
        public async Task Delete(int id)
        {
            await Task.Run(() => {
                _bookRepository.Delete(id);
                _bookRepository.Commit();
            });
        }
    }
}
