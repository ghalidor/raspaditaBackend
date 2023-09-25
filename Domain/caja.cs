namespace Domain
{
    public class caja
    {
        public Int64 id { get; set; }
        public Int64 local_id { get; set; }
        public string local_nombre { get; set; }
        public string nombre { get; set; }
        public DateTime fecharegistro { get; set; }
        public string fecharegistro_string { get; set; }
        public DateTime fechaupdated { get; set; }
        public string fechaupdated_string { get; set; }
        public bool estado { get; set; }
        public string estado_string { get; set; }
        public string clase { get; set; }

    }

    public class cajaNuevo
    {      
        public Int64 local_id { get; set; }
        public string nombre { get; set; }
       
    }

    public class cajaEditar
    {
        public Int64 id { get; set; }
        public Int64 local_id { get; set; }
        public string nombre { get; set; }
        public bool estado { get; set; }
    }
}