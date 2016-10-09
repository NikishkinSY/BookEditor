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
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(
            IAuthorRepository authorRepository,
            ILogger<AuthorController> logger)
        {
            _authorRepository = authorRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<AuthorViewModel>> Get()
        {
            return await Task.Run(() => { return _authorRepository.GetAll().Select(x => Automapper.Map(x)); });
        }

        [HttpPost]
        public async Task<int> Add([FromBody]AuthorViewModel author)
        {
            if (ModelState.IsValid)
            {
                return await Task.Run(() =>
                {
                    var _author = Automapper.Map(author);
                    _authorRepository.Add(_author);
                    _authorRepository.Commit();
                    return _author.Id;
                });
            }
            else
                return -1;

        }

        [HttpPost]
        public async Task Delete(int id)
        {
            await Task.Run(() => {
                _authorRepository.Delete(id);
                _authorRepository.Commit();
            });
        }
    }
}
