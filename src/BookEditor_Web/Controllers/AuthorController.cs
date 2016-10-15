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
            return Mapper.Map<IEnumerable<AuthorViewModel>>(await _authorRepository.GetAllAsync());
        }

        [HttpPost]
        public async Task<int> Add([FromBody]AuthorViewModel author)
        {
            if (ModelState.IsValid)
            {
                var _author = Mapper.Map<Author>(author);
                _authorRepository.Add(_author);
                await _authorRepository.CommitAsync();
                return _author.Id;
            }
            else
                return -1;

        }

        [HttpPost]
        public async Task Delete(int id)
        {
            _authorRepository.Delete(id);
            await _authorRepository.CommitAsync();
        }
    }
}
