using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sol.Pierr.Grimaldo.Application.Interfaces;
using Sol.Pierr.Grimaldo.CrossCutting.Common.Exceptions;
using Sol.Pierr.Grimaldo.CrossCutting.Dto.Base;
using static Sol.Pierr.Grimaldo.CrossCutting.Common.Constants.Constants;
using System.Threading.Tasks;
using System;
using Sol.Pierr.Grimaldo.Domain.Model.Model;
using System.Collections.Generic;

namespace Sol.Pierr.Grimaldo.DistributedServices.Web.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ISolicitudPrestamoApplication _solicitudPrestamoApplication;
        public LibrosController(ISolicitudPrestamoApplication solicitudPrestamoApplication)
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
        public async Task<IActionResult> GetLibros()
        {
            List<LibroEntity> response = await SolicitudPrestamoApplication.GetLibroAsync();
            return Json(JsonConvert.SerializeObject(response));
        }
 
    }
}
