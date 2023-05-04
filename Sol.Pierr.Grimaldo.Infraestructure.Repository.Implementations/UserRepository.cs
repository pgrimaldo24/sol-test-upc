using Microsoft.EntityFrameworkCore;
using Sol.Pierr.Grimaldo.Domain.Model.Model;
using Sol.Pierr.Grimaldo.Infraestructure.Persistence;
using Sol.Pierr.Grimaldo.Infraestructure.Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sol.Pierr.Grimaldo.Infraestructure.Repository.Implementations
{
    public class UserRepository : BaseRepository<DataContext, UsuarioEntity>, IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext) : base(dataContext) 
        {
            _dataContext = dataContext;
        }

        public async Task<UsuarioEntity> UserValidationAsync(string user, string pass)
        {
            var query = await _dataContext.Usuarios.
                            Where(x => x.Username == user &&
                                    x.Password == pass && 
                                    x.Ishabilitado == Convert.ToBoolean(1))
                            .FirstOrDefaultAsync();
            return query;
        }
    }
}
