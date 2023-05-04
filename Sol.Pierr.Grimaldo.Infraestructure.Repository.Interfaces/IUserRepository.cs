using Sol.Pierr.Grimaldo.Domain.Model.Model;
using System.Threading.Tasks;

namespace Sol.Pierr.Grimaldo.Infraestructure.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<UsuarioEntity> UserValidationAsync(string user, string pass);
    }
}
