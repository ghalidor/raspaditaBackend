
namespace Domain
{
    public class ticket
    {
        public Int64 id { get; set; }
        public string nroticket { get; set; }
        public Int64 apertura_id { get; set; }
        public Int64 caja_id { get; set; }
        public string caja_nombre { get; set; }
        public Int64 puntojuego_id { get; set; }
        public string puntojuego_ip { get; set; }
        public string puntojuego_nombre { get; set; }
        public int credito { get; set; }
        public float monto { get; set; }
        public DateTime fecharegistro { get; set; }
        public string fecharegistro_string { get; set; }
        public DateTime fechacobro { get; set; }
        public string fechacobro_string { get; set; }
        public string comprobantepagonro { get; set; }
        public bool estado { get; set; }
        public string estado_string { get; set; }
        public bool estadopago { get; set; }
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


    public class ticketPago
    {
        public Int64 id { get; set; }
        public Int64 caja_id { get; set; }
        public Int64 usuario_id { get; set; }
        public string caja_nombre { get; set; }
        public string nroticket { get; set; }
        public float monto { get; set; }
        public DateTime fecharegistro { get; set; }
        public string fecharegistro_string { get; set; }

    }


    public class ticketSaldo
    {
        public Int64 id { get; set; }
        public Int64 caja_id { get; set; }
        public Int64 usuario_id { get; set; }
        public string caja_nombre { get; set; }
        public string nroticket { get; set; }
        public string nroticketpago { get; set; }
        public float monto { get; set; }
        public DateTime fecharegistro { get; set; }
        public string fecharegistro_string { get; set; }
        public bool estadopago { get; set; }
        public DateTime fechapago { get; set; }
        public string fechapago_string { get; set; }
        public bool response { get; set; }
        public string message { get; set; }
    }

    public class createticketPago
    {
        public Int64 usuario_id { get; set; }
        public Int64 caja_id { get; set; }
        public Int64 ticket_id { get; set; }
        public string nroticket { get; set; }
        public float monto { get; set; }
        public DateTime fecharegistro { get; set; }

    }

    public class tickettransaccion
    {
        public Int64 ticket_id { get; set; }
        public Int64 apertura_id { get; set; }
        public bool acreditado { get; set; }
        public float credito { get; set; }
        public float monto { get; set; }
        public DateTime fecharegistro { get; set; }
        public Int64 transaccion_id { get; set; }
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

    public class ticketPagar
    {
        public Int64 caja_id { get; set; }
        public string nroticket { get; set; }

    }

    public class ticketPagoDetalle
    {
        public Int64 id { get; set; }
        public Int64 caja_id { get; set; }
        public Int64 ticket_id { get; set; }
        public string nroticket { get; set; }
        public float monto { get; set; }
        public DateTime fecharegistro { get; set; }

    }
}
