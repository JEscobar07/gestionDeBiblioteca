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
            var loans = await bdLibrary.Loans
                                        .Include(l => l.IdBookNavigation)
                                        .Include(l => l.IdClientNavigation)
                                        .ToListAsync();


            var viewModel = new LoanViewModel
            {
                Loans = loans,
                Books = await bdLibrary.Books.ToListAsync(),
                Clients = await bdLibrary.Clients.ToListAsync(),
                NewLoan = new Loan()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLoan(LoanViewModel loan)
        {
            var newLoan = loan.NewLoan;
            newLoan.ReturnDate = null;
            bdLibrary.Loans.Add(newLoan);
            await bdLibrary.SaveChangesAsync();
            return RedirectToAction(nameof(IndexLoan));
        }
    }
}

