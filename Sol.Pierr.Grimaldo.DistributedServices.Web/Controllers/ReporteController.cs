using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sol.Pierr.Grimaldo.Application.Interfaces;
using Sol.Pierr.Grimaldo.Domain.Model.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sol.Pierr.Grimaldo.DistributedServices.Web.Controllers
{
    public class ReporteController : Controller
    {
        private readonly ISolicitudPrestamoApplication _solicitudPrestamoApplication;
        public ReporteController(ISolicitudPrestamoApplication solicitudPrestamoApplication)
        {
            _solicitudPrestamoApplication = solicitudPrestamoApplication;
        }

        private ISolicitudPrestamoApplication SolicitudPrestamoApplication => _solicitudPrestamoApplication;

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            List<LibroEntity> response = await SolicitudPrestamoApplication.GetAllAsync();
            return Json(JsonConvert.SerializeObject(response));
        }
    }
}
