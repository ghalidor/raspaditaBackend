
namespace Domain
{
    public class envio
    {
        public Int64 id { get; set; }
        public string nroticket  { get; set; }    
        public Int64 puntojuego_id { get; set; }
        public int credito { get; set; }
        public DateTime fecharegistro { get; set; }
        public bool estado { get; set; }
    }

    public class envioNuevo
    {
        public string nroticket { get; set; }
        public Int64 puntojuego_id { get; set; }
        public int credito { get; set; }
    }
}
