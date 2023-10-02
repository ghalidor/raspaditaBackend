
namespace Domain
{
    public class permiso
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public string method { get; set; }
        public string controlador { get; set; }
        public string uri { get; set; }
        public string action { get; set; }
        public string resumen { get; set; }
        public string descripcion { get; set; }
        public string nombrealterno { get; set; }
        public DateTime fecharegistro { get; set; }
        public bool estado { get; set; }
    }
}
