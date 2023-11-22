using System;
using System.Collections.Generic;

namespace ENTIDADES.Models;

public class Costo
{
    public int IdCosto { get; set; }

    public int? Precio { get; set; }

    public virtual ICollection<Pelicula> Peliculas { get; set; } = new List<Pelicula>();
}
