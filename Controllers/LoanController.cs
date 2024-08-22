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

namespace gestionDeBiblioteca.Controllers
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
            List<Loan> loans = await bdLibrary.Loans.ToListAsync();
            return View(loans);
        }

    }
}