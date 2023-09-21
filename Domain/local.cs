
namespace Domain
{
    public class local
    {
        public Int64 id { get; set; }
        public Int64 nombre { get; set; }
        public DateTime direccion { get; set; }
        public DateTime fecharegistro { get; set; }
        public bool formato { get; set; } //1 moneda; 2 credito
        public bool estado { get; set; }
    }

    public class localNuevo
    {
        public Int64 nombre { get; set; }
        public DateTime direccion { get; set; }
        public bool formato { get; set; } //1 moneda; 2 credito
    }
}
