using Sol.Pierr.Grimaldo.Domain.Model.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sol.Pierr.Grimaldo.Infraestructure.Repository.Interfaces
{
    public interface ILibroRepository
    {
        Task<List<LibroEntity>> GetAllAsync(); 
    }
}
