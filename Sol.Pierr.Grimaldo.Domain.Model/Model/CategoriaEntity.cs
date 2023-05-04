using System;

namespace Sol.Pierr.Grimaldo.Domain.Model.Model
{
    public class CategoriaEntity
    {
        public int Categoriaid { get; set; }
        public string Name { get; set; }
        public bool? Isactive { get; set; }
        public string Createdby { get; set; }
        public DateTime Createdat { get; set; }
    }
}
