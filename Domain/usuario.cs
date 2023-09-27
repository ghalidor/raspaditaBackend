
namespace Domain
{
    public class usuarioLogin
    {
        public string nombre { get; set; }
        public string password { get; set; }
    }

    public class usuarioResponse
    {
        public string nombre { get; set; }
        public Int64 id { get; set; }
        public Int64 caja_id { get; set; }
        public string caja_nombre { get; set; }
        public Int64 local_id { get; set; }
        public string local_nombre { get; set; }
        public string token { get; set; }
        public bool response { get; set; }
        public string message { get; set; }
    }

    public class usuario
    {
        public Int64 id { get; set; }
        public string nombre { get; set; }
        public string password { get; set; }
        public Int64 usuariolocal_id { get; set; }
        public Int64 caja_id { get; set; }
        public string caja_nombre { get; set; }
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

    public class usuarioCheck
    {
        public Int64 id { get; set; }
        public string nombre { get; set; }
        public string password { get; set; }
        public Int64 usuariolocal_id { get; set; }
        public Int64 caja_id { get; set; }
        public string caja_nombre { get; set; }
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
        public bool check { get; set; }
    }

    public class usuarioLocal
    {
        public Int64 usuario_id { get; set; }
        public Int64 rol_id { get; set; }
        public Int64 usuariolocal_id { get; set; }
        public Int64 local_id { get; set; }
        public string local_nombre { get; set; }       
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
        public Int64 id { get; set; }
        public Int64 usuariocaja_id { get; set; }
        public Int64 caja_id { get; set; }
        public string caja_nombre { get; set; }
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

    public class usuarioCajaNuevo_
    {
        public Int64 usuario_id { get; set; }
        public Int64 usuariocaja_id { get; set; }
        public Int64 caja_id { get; set; }        
        public DateTime fecharegistro { get; set; }
        public bool estado { get; set; }
    }

    public class usuarioRol
    {
        public Int64 usuario_id { get; set; }
        public Int64 rol_id { get; set; }
        public Int64 usuariorol_id { get; set; }      
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

    public class usuarioCajaNuevo
    {
        public Int64 caja_id { get; set; }
        public Int64 local_id { get; set; }
        public Int64 usuario_id { get; set; }
    }

    public class usuarioEditar
    {
        public Int64 id { get; set; }
        public Int64 usuariolocal_id { get; set; }
        public Int64 local_id { get; set; }
        public Int64 usuariorol_id { get; set; }
        public Int64 rol_id { get; set; }
        public string nombre { get; set; }
        public bool estado { get; set; }
    }

    public class usuarioPassword
    {
        public Int64 id { get; set; }
        public string password { get; set; }
    }
}
