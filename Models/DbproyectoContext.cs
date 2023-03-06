using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CampeonatoFutbol.Models;

public partial class DbproyectoContext : DbContext
{
    public DbproyectoContext()
    {
    }

    public DbproyectoContext(DbContextOptions<DbproyectoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Amonestacion> Amonestacions { get; set; }

    public virtual DbSet<Campeonato> Campeonatos { get; set; }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<Gol> Gols { get; set; }

    public virtual DbSet<Jugador> Jugadors { get; set; }

    public virtual DbSet<Partido> Partidos { get; set; }

    public virtual DbSet<Presidente> Presidentes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local); Database=DBProyecto; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Amonestacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__amonesta__3213E83F3A72448F");

            entity.ToTable("amonestacion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.JugadorId).HasColumnName("jugador_id");
            entity.Property(e => e.PartidoId).HasColumnName("partido_id");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");

            entity.HasOne(d => d.Jugador).WithMany(p => p.Amonestacions)
                .HasForeignKey(d => d.JugadorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__amonestac__jugad__32E0915F");

            entity.HasOne(d => d.Partido).WithMany(p => p.Amonestacions)
                .HasForeignKey(d => d.PartidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__amonestac__parti__33D4B598");
        });

        modelBuilder.Entity<Campeonato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__campeona__3213E83F9B8A7E2B");

            entity.ToTable("campeonato");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaFin)
                .HasColumnType("date")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Temporada)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("temporada");
        });

        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__equipo__3213E83F1AEE2CB1");

            entity.ToTable("equipo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ImagenEquipo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imagen_equipo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Presidente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("presidente");
        });

        modelBuilder.Entity<Gol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__gol__3213E83FBB3020A3");

            entity.ToTable("gol");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.JugadorId).HasColumnName("jugador_id");
            entity.Property(e => e.Minuto).HasColumnName("minuto");
            entity.Property(e => e.PartidoId).HasColumnName("partido_id");

            entity.HasOne(d => d.Jugador).WithMany(p => p.Gols)
                .HasForeignKey(d => d.JugadorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__gol__jugador_id__36B12243");

            entity.HasOne(d => d.Partido).WithMany(p => p.Gols)
                .HasForeignKey(d => d.PartidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__gol__partido_id__37A5467C");
        });

        modelBuilder.Entity<Jugador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__jugador__3213E83F6FA66015");

            entity.ToTable("jugador");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Edad)
                .HasColumnType("date")
                .HasColumnName("edad");
            entity.Property(e => e.EquipoId).HasColumnName("equipo_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NumeroCamiseta)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numero_camiseta");

            entity.HasOne(d => d.Equipo).WithMany(p => p.Jugadors)
                .HasForeignKey(d => d.EquipoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__jugador__equipo___29572725");
        });

        modelBuilder.Entity<Partido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__partido__3213E83F4CE6CB52");

            entity.ToTable("partido");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EquipoLocalId).HasColumnName("equipo_local_id");
            entity.Property(e => e.EquipoVisitanteId).HasColumnName("equipo_visitante_id");
            entity.Property(e => e.FechaHora)
                .HasColumnType("datetime")
                .HasColumnName("fecha_hora");
            entity.Property(e => e.GolesLocal).HasColumnName("goles_local");
            entity.Property(e => e.GolesVisitante).HasColumnName("goles_visitante");

            entity.HasOne(d => d.EquipoLocal).WithMany(p => p.PartidoEquipoLocals)
                .HasForeignKey(d => d.EquipoLocalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__partido__equipo___2F10007B");

            entity.HasOne(d => d.EquipoVisitante).WithMany(p => p.PartidoEquipoVisitantes)
                .HasForeignKey(d => d.EquipoVisitanteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__partido__equipo___300424B4");
        });

        modelBuilder.Entity<Presidente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__presiden__3213E83FD521CAE8");

            entity.ToTable("presidente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.EquipoId).HasColumnName("equipo_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");

            entity.HasOne(d => d.Equipo).WithMany(p => p.Presidentes)
                .HasForeignKey(d => d.EquipoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__president__equip__2C3393D0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
