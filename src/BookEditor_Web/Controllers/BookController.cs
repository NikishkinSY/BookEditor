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
using BookEditor_Web.Models;
using AutoMapper;
using BookEditor_Model;
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
            
                return await Task.Run(() => {
                    try
                    {
                        return Mapper.Map<IEnumerable<BookViewModel>>(_bookRepository.GetAll());
                    }
                    catch (Exception ex)
                    {

                    }
                    return null;
                });
            
            
        }

        [HttpPost]
        public async Task Add([FromBody]BookViewModel book)
        {
            await Task.Run(() => { _bookRepository.Add(Mapper.Map<Book>(book)); });
        }

        [HttpPost]
        public async Task Edit([FromBody]BookViewModel book)
        {
            await Task.Run(() => { _bookRepository.Edit(Mapper.Map<Book>(book)); });
        }

        [HttpPost("{id}")]
        public async Task Delete(int id)
        {
            await Task.Run(() => { _bookRepository.Delete(id); });
        }
    }
}
