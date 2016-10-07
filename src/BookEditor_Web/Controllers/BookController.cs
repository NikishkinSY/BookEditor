using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookEditor_Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookEditor_Web.Controllers
{
    public class BookController : Controller
    {
        //private readonly IBookRepository _bookRepository;
        //public BookController(IBookRepository bookRepository)
        //{
        //    _bookRepository = bookRepository;
        //}
        public DbContext _test;
        public BookController(DbContext test)
        {
            _test = test;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            try
            {
                //var items = _bookRepository.GetAll();
            }
            catch (Exception ex)
            {
                
                throw;
            }
            
            return View();
        }
    }
}
