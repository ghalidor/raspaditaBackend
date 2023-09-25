
namespace Domain
{
    public class usuario
    {
        public Int64 id { get; set; }
        public string nombre { get; set; }
        public string password { get; set; }
        public DateTime fecharegistro { get; set; }
        public DateTime fechaupdated { get; set; }
        public bool estado { get; set; }
    }

    public class usuarioNuevo
    {
        public string nombre { get; set; }
        public string password { get; set; }
    }
}
