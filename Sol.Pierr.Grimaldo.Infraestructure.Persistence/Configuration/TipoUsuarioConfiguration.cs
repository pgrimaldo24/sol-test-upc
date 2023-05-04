using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sol.Pierr.Grimaldo.Domain.Model.Model;

namespace Sol.Pierr.Grimaldo.Infraestructure.Persistence.Configuration
{
    public class TipoUsuarioConfiguration : IEntityTypeConfiguration<TipoUsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<TipoUsuarioEntity> entity)
        {
            entity.ToTable("TYPEUSER");

            entity.HasKey(e => e.Typeuserid)
              .HasName("TYPEUSER_PK");

            entity.Property(e => e.Typeuserid)
                .HasPrecision(10)
                .HasColumnName("TYPEUSERID");

            entity.Property(e => e.Createdat)
                .HasColumnType("DATE")
                .HasColumnName("CREATEDAT")
                .HasDefaultValueSql("sysdate ");

            entity.Property(e => e.Createdby)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CREATEDBY")
                .HasDefaultValueSql("'ADMIN' ");

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");

            entity.Property(e => e.Isactive)
                .IsRequired()
                .HasPrecision(1)
                .HasColumnName("ISACTIVE")
                .HasDefaultValueSql("0 ");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");
        }
    }
}
