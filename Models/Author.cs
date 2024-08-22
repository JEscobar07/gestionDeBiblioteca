using System;
using System.Collections.Generic;

namespace gestionBiblioteca.Models;

public partial class Author
{
    public int IdAuthor { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
