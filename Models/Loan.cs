using System;
using System.Collections.Generic;

namespace gestionBiblioteca.Models;

public partial class Loan
{
    public int IdLoan { get; set; }

    public DateOnly DeliveryDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public int? IdBook { get; set; }

    public int? IdClient { get; set; }

    public virtual Book? IdBookNavigation { get; set; }

    public virtual Client? IdClientNavigation { get; set; }

    public virtual ICollection<Record> Records { get; set; } = new List<Record>();
}
