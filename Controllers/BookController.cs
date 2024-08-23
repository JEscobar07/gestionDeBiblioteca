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
        [HttpGet("Create")]
        public async Task<IActionResult> Create()
        {
            var lastBook = await _appDbContext.Books.OrderByDescending(b => b.IdBook).FirstOrDefaultAsync();
            var AuthorList = await _appDbContext.Authors.ToListAsync();
            var CategoryList = await _appDbContext.Categories.ToListAsync();
            int lastId = lastBook != null ? lastBook.IdBook : 0;
            ViewBag.LastBookId = lastId;
            ViewBag.AuthorList = AuthorList;
            ViewBag.CategoryList = CategoryList;
            return View();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(Book book)
        {
            _appDbContext.Books.Add(book);
            _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}