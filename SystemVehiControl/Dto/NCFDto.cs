namespace SystemVehiControl.Dto
{
    public class NCFDto
    {
        public int Id { get; set; }
        public string TipoNCF { get; set; }
        public int RangoInicio { get; set; }
        public int RangoFin { get; set; }
        public int SecuenciaActual { get; set; }
        public string CodigoVerificacion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string SecuenciaCompleta { get; set; }
    }
}
