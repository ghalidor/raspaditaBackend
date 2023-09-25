
namespace Domain
{
    public class ticket
    {
        public Int64 id { get; set; }
        public string nroticket  { get; set; }
        public Int64 caja_id { get; set; }
        public string caja_nombre { get; set; }
        public Int64 puntojuego_id { get; set; }
         public string puntojuego_ip { get; set; }
        public string puntojuego_nombre { get; set; }
        public int credito { get; set; }
        public float monto { get; set; }
        public DateTime fecharegistro { get; set; }
        public string fecharegistro_string { get; set; }
        public DateTime fechaupdated { get; set; }
        public string fechaupdated_string { get; set; }
        public bool estado { get; set; }
        public string estado_string { get; set; }
        public string clase { get; set; }
    }

    public class ticketNuevo
    {
        public Int64 caja_id { get; set; }
        public Int64 puntojuego_id { get; set; }
        public int credito { get; set; }
        public float monto { get; set; }
    }

    public class ticketCreado
    {
        public Int64 id { get; set; }
        public string nroticket { get; set; }
        public int credito { get; set; }
        public float monto { get; set; }
    }
}
