
namespace Domain
{
    public class usuario
    {
        public Int64 id { get; set; }
        public string nombre { get; set; }
        public string password { get; set; }
        public Int64 usuariolocal_id { get; set; }
        public Int64 local_id { get; set; }
        public string local_nombre { get; set; }
        public Int64 usuariorol_id { get; set; }
        public Int64 rol_id { get; set; }
        public string rol_nombre { get; set; }
        public DateTime fecharegistro { get; set; }
        public string fecharegistro_string { get; set; }
        public DateTime fechaupdated { get; set; }
        public string fechaupdated_string { get; set; }
        public bool estado { get; set; }
        public string estado_string { get; set; }
        public string clase { get; set; }
    }

    public class usuarioLocal
    {
        public Int64 usuario_id { get; set; }
        public Int64 rol_id { get; set; }
        public Int64 usuariolocal_id { get; set; }
        public Int64 local_id { get; set; }
        public Int64 local_nombre { get; set; }       
        public string nombre { get; set; }
        public string password { get; set; }
        public DateTime fecharegistro { get; set; }
        public string fecharegistro_string { get; set; }
        public DateTime fechaupdated { get; set; }
        public string fechaupdated_string { get; set; }
        public bool estado { get; set; }
        public string estado_string { get; set; }
        public string clase { get; set; }
    }

    public class usuarioCaja
    {
        public Int64 usuario_id { get; set; }
        public Int64 usuariocaja_id { get; set; }
        public Int64 caja_id { get; set; }
        public Int64 caja_nombre { get; set; }
        public string nombre { get; set; }
        public string password { get; set; }
        public DateTime fecharegistro { get; set; }
        public string fecharegistro_string { get; set; }
        public DateTime fechaupdated { get; set; }
        public string fechaupdated_string { get; set; }
        public bool estado { get; set; }
        public string estado_string { get; set; }
        public string clase { get; set; }
    }

    public class usuarioRol
    {
        public Int64 usuario_id { get; set; }
        public Int64 rol_id { get; set; }
        public Int64 usuarioRol_id { get; set; }      
        public DateTime fecharegistro { get; set; }
        public string fecharegistro_string { get; set; }
    }

    public class usuarioNuevo
    {
        public Int64 rol_id { get; set; }
        public Int64 local_id { get; set; }
        public string nombre { get; set; }
        public string password { get; set; }
    }

    public class usuarioEditar
    {
        public Int64 id { get; set; }
        public string nombre { get; set; }
        public bool estado { get; set; }
    }

    public class usuarioPassword
    {
        public Int64 id { get; set; }
        public string password { get; set; }
    }
}
