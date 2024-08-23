using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestionBiblioteca.Models;

namespace gestionBiblioteca.Models
{
    public class LoanViewModel
    {
        public List<Record> Records { get; set; }
        public List<Client> Clients { get; set; }
        public List<Book> Books {get; set;}
        public Loan NewLoan {get; set;}
    }
}