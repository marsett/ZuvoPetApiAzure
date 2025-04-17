namespace ZuvoPetApiAzure.DTO
{
    public class AdoptanteDTO
    {
        public string Nombre { get; set; }
        public string TipoVivienda { get; set; }
        public bool TieneJardin { get; set; }
        public bool OtrosAnimales { get; set; } // Ajustado a bool para coincidir con tu modelo
        public List<string> RecursosDisponibles { get; set; } // Lista de strings como en tu modelo
        public string TiempoEnCasa { get; set; }
    }
}
