using System;
using System.Collections.Generic;

namespace CampeonatoFutbol.Models;

public partial class Campeonato
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Temporada { get; set; } = null!;

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public string Descripcion { get; set; } = null!;
}
