namespace Domain
{
    public class caja
    {
        public Int64 id { get; set; }
        public Int64 local_id { get; set; }
        public DateTime fechaoperacion { get; set; }
        public DateTime fechaapertura { get; set; }
        public int nro_apertura { get; set; }
        public DateTime fechacierre { get; set; }
        public Int64 usuario_id { get; set; }
        public int estado { get; set; }
    }

    public class cajaNuevo
    {      
        public Int64 local_id { get; set; }
        public string fechaoperacion { get; set; }
        public string fechaapertura { get; set; }
        public int nro_apertura { get; set; }
        public string fechacierre { get; set; }
        public Int64 usuario_id { get; set; }
    }
}