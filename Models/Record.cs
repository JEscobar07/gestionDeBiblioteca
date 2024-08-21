using System;
using System.Collections.Generic;

namespace gestionBiblioteca.Models;

public partial class Record
{
    public int IdRecord { get; set; }

    public int Quantity { get; set; }

    public int? IdLoan { get; set; }

    public virtual Loan? IdLoanNavigation { get; set; }
}
