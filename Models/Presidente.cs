using System;
using System.Collections.Generic;

namespace CampeonatoFutbol.Models;

public partial class Presidente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public int Telefono { get; set; }

    public int EquipoId { get; set; }

    public virtual Equipo Equipo { get; set; } = null!;
}
