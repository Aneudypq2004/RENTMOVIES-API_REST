using System;
using System.Collections.Generic;

namespace ENTIDADES.Models;

public  class Direccion
{
    public int IdDireccion { get; set; }

    public string? DireccionMunicipio { get; set; }

    public string? DireccionSector { get; set; }

    public string? DireccionCalle { get; set; }

    public string? DireccionNumeroCasa { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
