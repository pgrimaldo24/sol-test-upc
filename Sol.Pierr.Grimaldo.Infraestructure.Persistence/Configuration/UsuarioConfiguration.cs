using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sol.Pierr.Grimaldo.Domain.Model.Model;

namespace Sol.Pierr.Grimaldo.Infraestructure.Persistence.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> entity)
        {
            entity.ToTable("USUARIO");

            entity.Property(e => e.Usuarioid)
                .HasPrecision(10)
                .HasColumnName("USUARIOID");

            entity.Property(e => e.Apellidos)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDOS");

            entity.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");

            entity.Property(e => e.Ishabilitado)
                .IsRequired()
                .HasPrecision(1)
                .HasColumnName("ISHABILITADO")
                .HasDefaultValueSql("1 ");

            entity.Property(e => e.Nombres)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRES");

            entity.Property(e => e.Telefono)
                .IsRequired()
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("TELEFONO")
                .IsFixedLength(true);
        }
    }
}
