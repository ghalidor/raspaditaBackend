
namespace Domain
{
    public class local
    {
        public Int64 id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public bool formato { get; set; } //1 moneda; 2 credito
        public DateTime fecharegistro { get; set; }
        public string fecharegistro_string { get; set; }
        public DateTime fechaupdated { get; set; }
        public bool estado { get; set; }
        public string estado_string { get; set; }
        public string clase { get; set; }
    }

    public class localNuevo
    {
        public string nombre { get; set; }
        public string direccion { get; set; }
        public bool formato { get; set; } //1 moneda; 2 credito
    }

    public class localEditar
    {
        public Int64 id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public bool formato { get; set; } //1 moneda; 2 credito
        public bool estado { get; set; }
    }
}
