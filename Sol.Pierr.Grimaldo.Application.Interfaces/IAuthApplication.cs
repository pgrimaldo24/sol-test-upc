using Sol.Pierr.Grimaldo.CrossCutting.Dto;
using Sol.Pierr.Grimaldo.CrossCutting.Dto.Base;
using System.Threading.Tasks;

namespace Sol.Pierr.Grimaldo.Application.Interfaces
{
    public interface IAuthApplication
    {
        Task<ResponseDto> AuthAsync(string user, string password);
    }
}
