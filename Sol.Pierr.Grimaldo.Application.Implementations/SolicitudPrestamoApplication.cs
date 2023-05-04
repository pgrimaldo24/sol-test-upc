using Sol.Pierr.Grimaldo.Application.Interfaces;
using Sol.Pierr.Grimaldo.CrossCutting.Dto;
using Sol.Pierr.Grimaldo.CrossCutting.Dto.Base;
using Sol.Pierr.Grimaldo.Domain.Model.Model;
using Sol.Pierr.Grimaldo.Infraestructure.Repository.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sol.Pierr.Grimaldo.Application.Implementations
{ 
    public class SolicitudPrestamoApplication : ISolicitudPrestamoApplication
    {
        private readonly IUnitOfWork _unitOfWork;

        public SolicitudPrestamoApplication(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        } 
        private IUnitOfWork UnitOfWork => _unitOfWork;

        public async Task<List<ReporteDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<LibroEntity>> GetLibroAsync()
        {
            return await UnitOfWork.LibroRepository.GetAllAsync(); 
        }
  
        public async Task<ResponseDto> RegisterLoanApplicationAsync(string nombres, 
            string apellidos, string numdoc, string telefono, string email, string direccion, int dpdTipoAlumno, int dpdTipoLectura, DateTime txtFechaDevolucion)
        {
            var responseDto = new ResponseDto(); 
            var entity = new UsuarioEntity();
            entity.Nombres = nombres;
            entity.Apellidos = apellidos;
            entity.DocumentoNumero = numdoc;
            entity.Telefono = telefono;
            entity.Email = email;
            entity.IsSancionado = false;
            entity.Direccion = direccion;
            entity.Tipousuarioid = dpdTipoAlumno;
            entity.Username = "generico";
            entity.Password = "123";
            UnitOfWork.Set<UsuarioEntity>().Add(entity);
            UnitOfWork.SaveChanges();
             
            var prestamo = new PrestamoEntity();
            prestamo.Usuarioid = entity.Usuarioid;
            prestamo.Tipoprestamoid = dpdTipoLectura;
            prestamo.FechaPrestamo = DateTime.Now;
            prestamo.FechaDevolucion = txtFechaDevolucion;
            UnitOfWork.Set<PrestamoEntity>().Add(prestamo);
            UnitOfWork.SaveChanges();


            responseDto.Message = "La solicitud de registró correctamente.";
            return responseDto;
        }
    }
}
