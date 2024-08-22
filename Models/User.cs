using System;
using System.Collections.Generic;

namespace gestionBiblioteca.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? IdRol { get; set; }

    public virtual Role? IdRolNavigation { get; set; }
}
