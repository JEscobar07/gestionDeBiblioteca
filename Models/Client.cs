using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestionDeBiblioteca.Models
{
    public class Client
    {
        public int Id {get; set;}
        public string TypeDocument { get; set; }
        public string Document { get; set; }
        public string NameComplet { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address {get; set;}
    }
}