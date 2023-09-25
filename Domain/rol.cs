
namespace Domain
{
    public class rol
    {
        public Int64 id { get; set; }
        public string nombre { get; set; }     
        public DateTime fecharegistro { get; set; }
        public string fecharegistro_string { get; set; }
        public bool estado { get; set; }
        public string estado_string { get; set; }
        public string clase { get; set; }
    }

    public class rolNuevo
    {
        public string nombre { get; set; }
    }

    public class rolEditar
    {
        public Int64 id { get; set; }
        public string nombre { get; set; }
        public bool estado { get; set; }
    }

}
