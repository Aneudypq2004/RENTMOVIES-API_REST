using System;
using System.Collections.Generic;

namespace ENTIDADES.Models;

public  class Pelicula
{
    public int IdPeli { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? CategoriaId { get; set; }

    public int? CostoRentaId { get; set; }

    public int? IsDisponible { get; set; }

    public virtual ICollection<Alquiler> Alquilers { get; set; } = new List<Alquiler>();

    public virtual Categorium? Categoria { get; set; }

    public virtual Costo? CostoRenta { get; set; }
}
