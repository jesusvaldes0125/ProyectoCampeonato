using System;
using System.Collections.Generic;

namespace CampeonatoFutbol.Models;

public partial class Jugador
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string NumeroCamiseta { get; set; } = null!;

    public DateTime Edad { get; set; }

    public int EquipoId { get; set; }

    public virtual ICollection<Amonestacion> Amonestacions { get; } = new List<Amonestacion>();

    public virtual Equipo Equipo { get; set; } = null!;

    public virtual ICollection<Gol> Gols { get; } = new List<Gol>();
}
