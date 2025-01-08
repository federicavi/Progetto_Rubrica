using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Prova_Rubrica.Models;

namespace Prova_Rubrica.ContextDb;

public partial class ProvaRubricaContext : DbContext
{
    public ProvaRubricaContext()
    {
    }

    public ProvaRubricaContext(DbContextOptions<ProvaRubricaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ContattiPersonali> ContattiPersonalis { get; set; }

    public virtual DbSet<NumeriUtili> NumeriUtilis { get; set; }

    public virtual DbSet<Persone> Persones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=sqlServerstring");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContattiPersonali>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contatti__3214EC07A91DE954");

            entity.ToTable("ContattiPersonali");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");
            entity.Property(e => e.Telefono)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.ContattiPersonalis)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK_ContattiPersonali_Persone");
        });

        modelBuilder.Entity<NumeriUtili>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NumeriUt__3214EC075D8A3F86");

            entity.ToTable("NumeriUtili");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Number)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Persone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Persone__3214EC07BCF63E1A");

            entity.ToTable("Persone");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
