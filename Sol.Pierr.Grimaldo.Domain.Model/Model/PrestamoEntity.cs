using System;

namespace Sol.Pierr.Grimaldo.Domain.Model.Model
{
    public class PrestamoEntity
    {
        public int Prestamoid { get; set; }
        public int Usuarioid { get; set; }
        public int Tipoprestamoid { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
    }
}
