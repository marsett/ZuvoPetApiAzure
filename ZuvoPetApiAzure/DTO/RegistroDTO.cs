namespace ZuvoPetApiAzure.DTO
{
    public class RegistroDTO
    {
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string ContrasenaLimpia { get; set; }
        public string TipoUsuario { get; set; } // "Adoptante" o "Refugio"
        public AdoptanteDTO DatosAdoptante { get; set; }
        public RefugioDTO DatosRefugio { get; set; }
    }
}
