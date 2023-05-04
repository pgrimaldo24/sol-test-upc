using Microsoft.EntityFrameworkCore;
using Sol.Pierr.Grimaldo.Domain.Model.Model;
using Sol.Pierr.Grimaldo.Infraestructure.Persistence;
using Sol.Pierr.Grimaldo.Infraestructure.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol.Pierr.Grimaldo.Infraestructure.Repository.Implementations
{
    public class LibroRepository : BaseRepository<DataContext, LibroEntity>, ILibroRepository
    {
        private readonly DataContext _dataContext;
        public LibroRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<LibroEntity>> GetAllAsync()
        {
            var query = await _dataContext.Libros.ToListAsync();
            return query;
        } 
    }
}
