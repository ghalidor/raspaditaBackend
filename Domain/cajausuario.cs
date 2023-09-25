
namespace Domain
{
    public class cajausuario
    {
        public Int64 id { get; set; }
        public Int64 usuario_id { get; set; }
        public Int64 caja_id { get; set; }
        public DateTime fecharegistro { get; set; }
        public string fecharegistro_string { get; set; }
        public bool estado { get; set; }
        public string estado_string { get; set; }
        public string clase { get; set; }
    }

}
