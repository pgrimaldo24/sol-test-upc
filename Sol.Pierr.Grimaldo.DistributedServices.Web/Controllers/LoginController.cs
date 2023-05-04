using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sol.Pierr.Grimaldo.Application.Interfaces;
using Sol.Pierr.Grimaldo.CrossCutting.Common.Exceptions;
using Sol.Pierr.Grimaldo.CrossCutting.Dto;
using Sol.Pierr.Grimaldo.CrossCutting.Dto.Base;
using System;
using System.Threading.Tasks;
using static Sol.Pierr.Grimaldo.CrossCutting.Common.Constants.Constants;

namespace Sol.Pierr.Grimaldo.DistributedServices.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthApplication _authApplication;
        public LoginController(IAuthApplication authApplication)
        {
            _authApplication = authApplication;
        }

        private IAuthApplication AuthApplication => _authApplication;

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
         
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AutenticacionUsuario(string user, string password)
        {
            ResponseDto response;
            try
            {
                response = await AuthApplication.AuthAsync(user, password); 
            }
            catch (FunctionalException ex)
            {
                response = new ResponseDto { Status = ex.FuntionalCode, Message = ex.Message, Data = ex.Data, TransactionId = ex.TransactionId };
            }
            catch (TechnicalException ex)
            {
                response = new ResponseDto { Status = ex.ErrorCode, Message = ex.Message, Data = ex.Data, TransactionId = ex.TransactionId }; 
            }
            catch (Exception ex)
            {
                response = new ResponseDto { Status = SystemStatusCode.TechnicalError, Message = ex.Message }; 
            }
            return Json(JsonConvert.SerializeObject(response));
        }
    }
}
