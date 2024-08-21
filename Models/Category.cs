using System;
using System.Collections.Generic;

namespace gestionBiblioteca.Models;

public partial class Category
{
    public int IdCategory { get; set; }

    public string TypeCategory { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
