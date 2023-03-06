using System;
using System.Collections.Generic;

namespace CampeonatoFutbol.Models;

public partial class Amonestacion
{
    public int Id { get; set; }

    public int JugadorId { get; set; }

    public int PartidoId { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual Jugador Jugador { get; set; } = null!;

    public virtual Partido Partido { get; set; } = null!;
}
