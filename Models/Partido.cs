using System;
using System.Collections.Generic;

namespace CampeonatoFutbol.Models;

public partial class Partido
{
    public int Id { get; set; }

    public DateTime FechaHora { get; set; }

    public int EquipoLocalId { get; set; }

    public int EquipoVisitanteId { get; set; }

    public int GolesLocal { get; set; }

    public int GolesVisitante { get; set; }

    public virtual ICollection<Amonestacion> Amonestacions { get; } = new List<Amonestacion>();

    public virtual Equipo EquipoLocal { get; set; } = null!;

    public virtual Equipo EquipoVisitante { get; set; } = null!;

    public virtual ICollection<Gol> Gols { get; } = new List<Gol>();
}
