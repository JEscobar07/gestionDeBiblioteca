using System;
using System.Collections.Generic;

namespace gestionBiblioteca.Models;

public partial class Permission
{
    public int IdPermission { get; set; }

    public string Name { get; set; } = null!;

    public bool Status { get; set; }

    public virtual ICollection<RolesPermission> RolesPermissions { get; set; } = new List<RolesPermission>();
}
