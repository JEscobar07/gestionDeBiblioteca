using System;
using System.Collections.Generic;

namespace gestionBiblioteca.Models;

public partial class Client
{
    public int IdClient { get; set; }

    public string TypeDocument { get; set; } = null!;

    public string Document { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
