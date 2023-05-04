namespace Sol.Pierr.Grimaldo.Domain.Model.Model
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
        public int Tipousuarioid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DocumentoNumero { get; set; }
        public bool? IsSancionado { get; set; }
    }
}
