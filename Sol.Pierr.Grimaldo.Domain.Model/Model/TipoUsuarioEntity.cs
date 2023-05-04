using System;

namespace Sol.Pierr.Grimaldo.Domain.Model.Model
{
    public class TipoUsuarioEntity
    {
        public int Typeuserid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Isactive { get; set; }
        public string Createdby { get; set; }
        public DateTime Createdat { get; set; }
    }
}
