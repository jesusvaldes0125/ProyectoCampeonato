using System;
using System.Collections.Generic;

namespace CampeonatoFutbol.Models;

public partial class Equipo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Presidente { get; set; } = null!;

    public string ImagenEquipo { get; set; } = null!;

    public virtual ICollection<Jugador> Jugadors { get; } = new List<Jugador>();

    public virtual ICollection<Partido> PartidoEquipoLocals { get; } = new List<Partido>();

    public virtual ICollection<Partido> PartidoEquipoVisitantes { get; } = new List<Partido>();

    public virtual ICollection<Presidente> Presidentes { get; } = new List<Presidente>();
}
