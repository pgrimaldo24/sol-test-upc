using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sol.Pierr.Grimaldo.Domain.Model.Model;

namespace Sol.Pierr.Grimaldo.Infraestructure.Persistence.Configuration
{
    public class PrestamoConfiguration : IEntityTypeConfiguration<PrestamoEntity>
    {
        public void Configure(EntityTypeBuilder<PrestamoEntity> entity)
        {
            entity.ToTable("PRESTAMOS");

            entity.Property(e => e.Prestamoid)
                .HasPrecision(10)
                .HasColumnName("PRESTAMOID");

            entity.Property(e => e.FechaDevolucion)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_DEVOLUCION");

            entity.Property(e => e.FechaPrestamo)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_PRESTAMO");

            entity.Property(e => e.Tipoprestamoid)
                .HasPrecision(10)
                .HasColumnName("TIPOPRESTAMOID");

            entity.Property(e => e.Usuarioid)
                .HasPrecision(10)
                .HasColumnName("USUARIOID");
        }
    }
}
