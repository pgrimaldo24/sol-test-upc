﻿namespace Sol.Pierr.Grimaldo.Domain.Model.Model
{
    public class UsuarioEntity
    {
        public int Usuarioid { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool? Ishabilitado { get; set; }
    }
}
