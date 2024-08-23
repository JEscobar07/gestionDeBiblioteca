using System;
using System.Collections.Generic;

namespace gestionBiblioteca.Models;

public partial class RolesPermission
{
    public int IdRolPermission { get; set; }

    public int? IdRol { get; set; }

    public int? IdPermission { get; set; }

    public virtual Permission? IdPermissionNavigation { get; set; }

    public virtual Role? IdRolNavigation { get; set; }
}
