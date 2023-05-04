using System;
using System.Collections.Generic;

#nullable disable

namespace Sol.Pierr.Grimaldo.Infraestructure.Persistence.Models
{
    public partial class Categorium
    {
        public int Categoriaid { get; set; }
        public string Name { get; set; }
        public bool? Isactive { get; set; }
        public string Createdby { get; set; }
        public DateTime Createdat { get; set; }
    }
}
