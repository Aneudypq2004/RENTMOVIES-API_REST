using System;
using System.Collections.Generic;

namespace ENTIDADES.Models;

public partial class Role
{
    public int Id { get; set; }

    public bool? Admin { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
