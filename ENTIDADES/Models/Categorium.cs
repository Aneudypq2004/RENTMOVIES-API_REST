using System;
using System.Collections.Generic;

namespace ENTIDADES.Models;

public  class Categorium
{
    public int IdCategoria { get; set; }

    public string? Categoria { get; set; }

    public int? EdadRecomendada { get; set; }

    public virtual ICollection<Pelicula> Peliculas { get; set; } = new List<Pelicula>();
}
