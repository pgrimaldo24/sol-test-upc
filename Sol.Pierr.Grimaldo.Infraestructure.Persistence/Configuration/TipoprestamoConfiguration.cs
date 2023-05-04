using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sol.Pierr.Grimaldo.Domain.Model.Model;

namespace Sol.Pierr.Grimaldo.Infraestructure.Persistence.Configuration
{
    public class TipoprestamoConfiguration : IEntityTypeConfiguration<TipoprestamoEntity>
    {
        public void Configure(EntityTypeBuilder<TipoprestamoEntity> entity)
        {
            entity.ToTable("TIPOPRESTAMO");

            entity.Property(e => e.Tipoprestamoid)
                .HasPrecision(10)
                .HasColumnName("TIPOPRESTAMOID");

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

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
        }
    }
}
