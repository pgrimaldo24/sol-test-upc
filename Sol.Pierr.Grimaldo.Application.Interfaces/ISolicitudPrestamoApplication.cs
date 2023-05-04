using Sol.Pierr.Grimaldo.CrossCutting.Dto;
using Sol.Pierr.Grimaldo.CrossCutting.Dto.Base;
using Sol.Pierr.Grimaldo.Domain.Model.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sol.Pierr.Grimaldo.Application.Interfaces
{
    public interface ISolicitudPrestamoApplication
    {
        Task<ResponseDto> RegisterLoanApplicationAsync(string nombres, string apellidos, string numdoc, string telefono, string email, string direccion, int dpdTipoAlumno, int dpdTipoLectura, DateTime txtFechaDevolucion);
        Task<List<LibroEntity>> GetLibroAsync();
        Task<List<ReporteDto>> GetAllAsync();
    }
}
