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

// Controlador utilizado en la vista IndexLoan.cshtml

namespace gestionBiblioteca.Controllers
{   
    //Controller 
    [Route("[controller]")]
    public class LoanController : Controller
    {
        private readonly Bfkxytwn9bgzdtfvozeuContext bdLibrary;

        // Constructor

        public LoanController(Bfkxytwn9bgzdtfvozeuContext _bdLibrary)
        {
            bdLibrary = _bdLibrary;
        }

        //Este index es el metodo que me permite traer la informacion de las tablas que se requieren en la vista junto con objetos para acceder a sus parametros
        public async Task<IActionResult> IndexLoan()
        {
            var records = await bdLibrary.Records
                                        .Include(l => l.IdLoanNavigation)
                                            .ThenInclude(l => l.IdBookNavigation)
                                        .ToListAsync();


            var viewModel = new LoanViewModel
            {
                Records = records,
                Books = await bdLibrary.Books.ToListAsync(),
                Clients = await bdLibrary.Clients.ToListAsync(),
                NewLoan = new Loan()
            };

            return View(viewModel);
        }

        //Este metodo creara un nuevo prestamo de partiendo del objeto utilizado en el metodo IndexLoan
        [HttpPost]
        public async Task<IActionResult> CreateLoan(LoanViewModel loan)
        {
            var newLoan = loan.NewLoan;
            newLoan.DeliveryDate = DateOnly.FromDateTime(DateTime.Now);
            newLoan.ReturnDate = null;
            bdLibrary.Loans.Add(newLoan);
            await bdLibrary.SaveChangesAsync();
            return RedirectToAction(nameof(IndexLoan));
        }


        // Método para devolver un préstamo
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

        // Método para editar un préstamo
        [HttpPost]
        public async Task<IActionResult> EditLoan(int id, int Id_Book, int Id_Client, DateTime Delivery_Date, DateTime? Return_Date)
        {
            var loan = await bdLibrary.Loans.FindAsync(id);
            if (loan != null)
            {
                loan.IdBook = Id_Book;
                loan.IdClient = Id_Client;
                loan.DeliveryDate = DateOnly.FromDateTime(Delivery_Date);
                loan.ReturnDate = Return_Date.HasValue ? DateOnly.FromDateTime(Return_Date.Value) : null;

                await bdLibrary.SaveChangesAsync();
            }

            return RedirectToAction(nameof(IndexLoan));
        }
    }
}

