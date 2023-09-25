
namespace Domain
{
    public class apertura
    {
        public Int64 id { get; set; }
        public Int64 caja_id { get; set; }
        public string caja_nombre { get; set; }
        public Int64 local_id { get; set; }
        public string local_nombre { get; set; }
        public DateTime fechaoperacion { get; set; }
        public string fechaoperacion_string { get; set; }
        public DateTime fechaapertura { get; set; }
        public string fechaapertura_string { get; set; }
        public int nro_apertura { get; set; }
        public DateTime fechacierre { get; set; }
        public string fechacierre_string { get; set; }
        public Int64 usuario_id { get; set; }
        public string usuario_nombre { get; set; }
        public int estado { get; set; }
        public string estado_string { get; set; }
        public string clase { get; set; }
    }
    public class aperturaNuevo
    {
        public Int64 caja_id { get; set; }
        public Int64 local_id { get; set; }       
    }

    public class aperturaCerrar
    {
        public Int64 id { get; set; }
        public Int64 caja_id { get; set; }
        public Int64 local_id { get; set; }

    }

}
