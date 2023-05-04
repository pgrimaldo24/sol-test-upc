using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sol.Pierr.Grimaldo.Domain.Model.Model;

namespace Sol.Pierr.Grimaldo.Infraestructure.Persistence.Configuration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<CategoriaEntity>
    {
        public void Configure(EntityTypeBuilder<CategoriaEntity> entity)
        {
            entity.HasKey(e => e.Categoriaid)
                   .HasName("CATEGORIA_PK");

            entity.ToTable("CATEGORIA");

            entity.Property(e => e.Categoriaid)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("CATEGORIAID");

            entity.Property(e => e.Createdat)
                .HasColumnType("DATE")
                .HasColumnName("CREATEDAT")
                .HasDefaultValueSql("SYSDATE ");

            entity.Property(e => e.Createdby)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CREATEDBY")
                .HasDefaultValueSql("'ADMIN' ");

            entity.Property(e => e.Isactive)
                .IsRequired()
                .HasPrecision(1)
                .HasColumnName("ISACTIVE")
                .HasDefaultValueSql("1 ");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
        }
    }
}
