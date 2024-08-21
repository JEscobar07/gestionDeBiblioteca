using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestionDeBiblioteca.Models
{
    public class Loans
    {
        public int Id { get; set; }
        public int Id_Book { get; set; }
        public int Id_Client { get; set; }
        public DateOnly Delivery_Date { get; set; }
        public DateOnly Return_Date { get; set; }
    }
}