using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using gestionBiblioteca.Models;
using gestionBiblioteca.Data;
using Microsoft.EntityFrameworkCore;

namespace gestionBiblioteca.Controllers
{
    [Route("[controller]")]
    public class LoanController : Controller
    {
        private readonly Bfkxytwn9bgzdtfvozeuContext bdLibrary;

        public LoanController(Bfkxytwn9bgzdtfvozeuContext _bdLibrary)
        {
            bdLibrary = _bdLibrary;
        }

        public async Task<IActionResult> IndexLoan()
        {
            var loans = await bdLibrary.Loans.ToListAsync();
            var books = await bdLibrary.Books.ToListAsync();
            var clients = await bdLibrary.Clients.ToListAsync();

            var viewModel = new LoanViewModel
            {
                Loans = loans,
                Books = books,
                Clients = clients
            };

            return View(viewModel); // Pasamos el modelo de vista a la vista
        }

        [HttpPost]
        [Route("Loan/ReturnLoan")]
        public async Task<IActionResult> ReturnLoan(int id)
        {
            var loan = await bdLibrary.Loans.FindAsync(id);

            if (loan == null)
            {
                return NotFound();
            }

            loan.ReturnDate = DateOnly.FromDateTime(DateTime.Now);
            bdLibrary.Loans.Update(loan);
            await bdLibrary.SaveChangesAsync();

            return RedirectToAction(nameof(IndexLoan));
        }
    }

}