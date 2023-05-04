using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sol.Pierr.Grimaldo.Application.Implementations;
using Sol.Pierr.Grimaldo.Application.Interfaces;
using Sol.Pierr.Grimaldo.CrossCutting.Common.Exceptions;
using Sol.Pierr.Grimaldo.CrossCutting.Dto.Base;
using static Sol.Pierr.Grimaldo.CrossCutting.Common.Constants.Constants;
using System.Threading.Tasks;
using System;

namespace Sol.Pierr.Grimaldo.DistributedServices.Web.Controllers
{
    public class SolicitudController : Controller
    { 
        private readonly ISolicitudPrestamoApplication _solicitudPrestamoApplication;
        public SolicitudController(ISolicitudPrestamoApplication solicitudPrestamoApplication)
        {
            _solicitudPrestamoApplication = solicitudPrestamoApplication;
        }

        private ISolicitudPrestamoApplication SolicitudPrestamoApplication => _solicitudPrestamoApplication;

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterLoanApplication(string nombres, 
            string apellidos, string numdoc, string telefono, string email, string direccion, int dpdTipoAlumno, int dpdTipoLectura, DateTime txtFechaDevolucion)
        {
            ResponseDto response;
            try
            {
                response = await SolicitudPrestamoApplication.RegisterLoanApplicationAsync(nombres, apellidos, numdoc, telefono, email, direccion, dpdTipoAlumno, dpdTipoLectura, txtFechaDevolucion);
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
