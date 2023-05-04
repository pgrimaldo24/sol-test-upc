using Microsoft.EntityFrameworkCore;
using Sol.Pierr.Grimaldo.Domain.Model.Model;
using Sol.Pierr.Grimaldo.Infraestructure.Persistence.Configuration;

namespace Sol.Pierr.Grimaldo.Infraestructure.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
            modelBuilder.ApplyConfiguration(new LibroConfiguration());
            modelBuilder.ApplyConfiguration(new TipoprestamoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new PrestamoConfiguration());
            modelBuilder.ApplyConfiguration(new TipoUsuarioConfiguration());
        }

        public virtual DbSet<CategoriaEntity> Categorias { get; set; }
        public virtual DbSet<LibroEntity> Libros { get; set; }
        public virtual DbSet<TipoprestamoEntity> Tipoprestamos { get; set; }
        public virtual DbSet<UsuarioEntity> Usuarios { get; set; }
        public virtual DbSet<PrestamoEntity> Prestamos { get; set; }
        public virtual DbSet<TipoUsuarioEntity> TipoUsuarios { get; set; }
    }
}
