
namespace Domain
{
    public class puntojuego
    {
        public Int64 id { get; set; }
        public Int64 local_id { get; set; }
        public int nro_punto { get; set; }
        public string ip { get; set; }
        public bool estado { get; set; }
    }

    public class puntojuegoNuevo
    {  
        public Int64 local_id { get; set; }
        public int nro_punto { get; set; }
        public string ip { get; set; }
    }
}
