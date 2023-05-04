using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sol.Pierr.Grimaldo.Domain.Model.Model;

namespace Sol.Pierr.Grimaldo.Infraestructure.Persistence.Configuration
{
    public class LibroConfiguration : IEntityTypeConfiguration<LibroEntity>
    {
        public void Configure(EntityTypeBuilder<LibroEntity> entity)
        {
            entity.HasNoKey();

            entity.ToTable("LIBROS");

            entity.Property(e => e.Autor)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("AUTOR")
                .HasDefaultValueSql("'Desconocido' ");

            entity.Property(e => e.Cantidad)
                .HasPrecision(3)
                .HasColumnName("CANTIDAD")
                .HasDefaultValueSql("0\n ");

            entity.Property(e => e.Editorial)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EDITORIAL");

            entity.Property(e => e.Precio)
                .HasColumnType("NUMBER(5,2)")
                .HasColumnName("PRECIO");

            entity.Property(e => e.Titulo)
                .IsRequired()
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TITULO");
        }
    }
}
