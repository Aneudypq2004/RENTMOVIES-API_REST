using System;
using System.Collections.Generic;

namespace ENTIDADES.Models;

public class Alquiler
{
    public int IdAlquiler { get; set; }

    public int? UsuarioId { get; set; }

    public int? PeliculaId { get; set; }

    public DateTime? FechaAlquiler { get; set; }

    public DateTime? FechaDevolucion { get; set; }

    public virtual Pelicula? Pelicula { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
