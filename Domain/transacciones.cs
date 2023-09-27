
namespace Domain
{
    public class transacciones
    {
        public Int64 id { get; set; }
        public Int64 caja_id { get; set; }
        public Int64 puntojuego_id { get; set; }
        public int jugada { get; set; }
        public bool premio { get; set; }
        public float importepremio { get; set; }
        public string nroticket { get; set; }
        public bool estadocobro { get; set; }
        public DateTime fechahorajugada { get; set; }
        public float saldoticketini { get; set; }       
        public float saldoticketfin { get; set; }
        public string comprobanteventa { get; set; }
        public string comprobantepagonro { get; set; }
        public DateTime fechacobro { get; set; }
        public bool estadopago { get; set; }
    }
    public class transaccionesNuevo
    {
        public Int64 caja_id { get; set; }
        public Int64 puntojuego_id { get; set; }
        public int jugada { get; set; }
        public bool premio { get; set; }
        public float importepremio { get; set; }
        public string nroticket { get; set; }
        public bool estadocobro { get; set; }
        public float saldoticketini { get; set; }
        public float saldoticketfin { get; set; }
        public string comprobanteventa { get; set; }
        public string comprobantepagonro { get; set; }
        public DateTime fechacobro { get; set; }
        public bool estadopago { get; set; }
    }
}
