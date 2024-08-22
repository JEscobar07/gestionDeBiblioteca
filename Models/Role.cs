using System;
using System.Collections.Generic;

namespace gestionBiblioteca.Models;

public partial class Role
{
    public int IdRol { get; set; }

    public string Name { get; set; } = null!;

    public bool Status { get; set; }

    public virtual ICollection<RolesPermission> RolesPermissions { get; set; } = new List<RolesPermission>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
