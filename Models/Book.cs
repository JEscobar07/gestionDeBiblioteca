using System;
using System.Collections.Generic;

namespace gestionBiblioteca.Models;

public partial class Book
{
    public int IdBook { get; set; }

    public string Title { get; set; } = null!;

    public bool Status { get; set; }

    public int? IdAuthor { get; set; }

    public int? IdCategory { get; set; }

    public virtual Author? IdAuthorNavigation { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
