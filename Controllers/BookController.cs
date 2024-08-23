using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using gestionBiblioteca.Models;
using gestionBiblioteca.Data;

namespace gestionDeBiblioteca.Controllers
{
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly Bfkxytwn9bgzdtfvozeuContext _appDbContext;
        public BookController(Bfkxytwn9bgzdtfvozeuContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            List<Book> BookList = await _appDbContext.Books.ToListAsync();
            var AuthorList = await _appDbContext.Authors.ToListAsync();
            var CategoryList = await _appDbContext.Categories.ToListAsync();
            ViewBag.AuthorList = AuthorList;
            ViewBag.CategoryList = CategoryList;
            return View(BookList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}