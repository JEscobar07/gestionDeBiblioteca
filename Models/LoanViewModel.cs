using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestionBiblioteca.Models;

namespace gestionBiblioteca.Models
{
    public class LoanViewModel
    {
        public List<Loan> Loans { get; set; }
        public List<Author> Authors { get; set; }
    }
}