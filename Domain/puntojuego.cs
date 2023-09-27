
namespace Domain
{
    public class puntojuego
    {
        public Int64 id { get; set; }
        public Int64 local_id { get; set; }
        public string local_nombre { get; set; }
        public int nro_punto { get; set; }
        public string ip { get; set; }
        public DateTime fecharegistro { get; set; }
        public string fecharegistro_string { get; set; }
        public DateTime fechaupdated { get; set; }
        public string fechaupdated_string { get; set; }
        public bool estado { get; set; }
        public string estado_string { get; set; }
        public Int64 posicion { get; set; }
        public string clase { get; set; }
    }

    public class puntojuegoNuevo
    {  
        public Int64 local_id { get; set; }
        public int nro_punto { get; set; }
        public string ip { get; set; }
    }

    public class puntojuegoEditar
    {
        public Int64 id { get; set; }
        public Int64 local_id { get; set; }
        public int nro_punto { get; set; }
        public string ip { get; set; }
        public bool estado { get; set; }
    }
}
