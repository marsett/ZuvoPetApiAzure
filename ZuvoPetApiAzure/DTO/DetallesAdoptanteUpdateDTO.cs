namespace ZuvoPetApiAzure.DTO
{
    public class DetallesAdoptanteUpdateDTO
    {
        public string TipoVivienda { get; set; }
        public List<string> RecursosDisponibles { get; set; }
        public string TiempoEnCasa { get; set; }
        public bool TieneJardin { get; set; }
        public bool OtrosAnimales { get; set; }
    }
}
