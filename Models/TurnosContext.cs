using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Models
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext> opciones)
        :base (opciones)
        {
            
        }
        public DbSet<Especialidad> Especialidad {get; set; }
        public DbSet<Paciente> Paciente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidad>(entidad =>
            {
                entidad.ToTable("Especialidad");

                entidad.HasKey(e => e.Id);

                entidad.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            });

            modelBuilder.Entity<Paciente>(entidad =>
            {
                entidad.ToTable("Paciente");

                entidad.HasKey(e => e.IdPaciente);

                entidad.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                entidad.Property(e => e.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entidad.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            });
        }

        public DbSet<Turnos.Models.Medico> Medico { get; set; }
    }
}