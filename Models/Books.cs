using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestionDeBiblioteca.Models
{
    public class Books
    {
        public int Id { get; set; }
        public int IdAutor { get; set; }
        public int IdCategory { get; set; }
        public string Title { get; set; }
        public string Estatus { get; set; }
    }
}