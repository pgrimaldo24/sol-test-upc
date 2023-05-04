using Sol.Pierr.Grimaldo.Application.Interfaces;
using Sol.Pierr.Grimaldo.CrossCutting.Dto;
using Sol.Pierr.Grimaldo.CrossCutting.Dto.Base;
using Sol.Pierr.Grimaldo.Infraestructure.Repository.Interfaces.Data;
using System.Threading.Tasks;
using static Sol.Pierr.Grimaldo.CrossCutting.Common.Constants.Constants;

namespace Sol.Pierr.Grimaldo.Application.Implementations
{
    public class AuthApplication : IAuthApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthApplication(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        private IUnitOfWork UnitOfWork => _unitOfWork;
       
        public async Task<ResponseDto> AuthAsync(string user, string password)
        {
            var response = new ResponseDto(); 
            var result = await UnitOfWork.UserRepository.UserValidationAsync(user, password);
            if(ReferenceEquals(result, null))
            {
                return new ResponseDto
                {
                    Status = SystemStatusCode.NotFound,
                    Message = "Se generó un error, no devolvío un usuario existente"
                };
            } 
            response.Data = result;
            return response;
        }
    }
}
