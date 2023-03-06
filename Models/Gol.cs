using System;
using System.Collections.Generic;

namespace CampeonatoFutbol.Models;

public partial class Gol
{
    public int Id { get; set; }

    public int JugadorId { get; set; }

    public int PartidoId { get; set; }

    public int Minuto { get; set; }

    public virtual Jugador Jugador { get; set; } = null!;

    public virtual Partido Partido { get; set; } = null!;
}
