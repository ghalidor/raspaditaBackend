
using Application.IRepository;
using Dapper;
using Domain;

namespace Persistence.Repository
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private readonly DapperContext _context;
        public UsuarioRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<usuario>> GetUsuarios()
        {
            var db = _context.CreateConnection();
            var sql = @"SELECT usu.[id]
      ,usu.[nombre]
      ,usu.[password]
      ,usulocal.id  usuariolocal_id
      ,loc.id local_id
      ,loc.nombre local_nombre
	  ,rlu.id usuariorol_id
	  ,rl.id rol_id
	  ,rl.nombre rol_nombre
      ,usu.[fecharegistro]
      ,usu.[fechaupdated]
      ,usu.[estado]
FROM [usuario] usu
left join usuariolocal usulocal on usulocal.usuario_id = usu.id
left join local loc on loc.id = usulocal.local_id
left join rolusuario rlu on rlu.usuario_id =  usu.id
left join rol rl on rl.id = rlu.rol_id
                    order by usu.id asc";
            return await db.QueryAsync<usuario>(sql);
        }

        public async Task<IEnumerable<usuario>> GetUsuarioLocal(Int64 local_id)
        {
            var db = _context.CreateConnection();
            var sql = @"SELECT usu.[id]
      ,usu.[nombre]
      ,usu.[password]
      ,usulocal.id  usuariolocal_id
      ,loc.id local_id
      ,loc.nombre local_nombre
	  ,rlu.id usuariorol_id
	  ,rl.id rol_id
	  ,rl.nombre rol_nombre
      ,usu.[fecharegistro]
      ,usu.[fechaupdated]
      ,usu.[estado]
FROM [usuario] usu
left join usuariolocal usulocal on usulocal.usuario_id = usu.id
left join local loc on loc.id = usulocal.local_id
left join rolusuario rlu on rlu.usuario_id =  usu.id
left join rol rl on rl.id = rlu.rol_id
                    where loc.id=@local_id 
                    order by usu.id asc";
            return await db.QueryAsync<usuario>(sql, new { local_id = local_id });
        }

        public async Task<IEnumerable<usuarioCaja>> GetUsuarioCaja(Int64 caja_id)
        {
            var db = _context.CreateConnection();
            var sql = @"SELECT usu.[id]
      ,usu.[nombre]
      ,usu.[password]
      ,cajausu.id usuariocaja_id
      ,cajausu.caja_id caja_id
      ,caj.nombre caja_nombre
      ,usu.[fecharegistro]
      ,usu.[fechaupdated]
      ,usu.[estado]
FROM [usuario] usu
left join cajausuario cajausu on cajausu.usuario_id = usu.id
left join caja caj on caj.id = cajausu.caja_id
                    where caj.id=@caja_id 
                    order by usu.id asc";
            return await db.QueryAsync<usuarioCaja>(sql, new { caja_id = caja_id });
        }

        public async Task<usuario> GetDetalleUsuario(Int64 id)
        {
            var db = _context.CreateConnection();
            var sql = @"SELECT usu.[id]
      ,usu.[nombre]
      ,usu.[password]
      ,usulocal.id  usuariolocal_id
      ,loc.id local_id
      ,loc.nombre local_nombre
	  ,rlu.id usuariorol_id
	  ,rl.id rol_id
	  ,rl.nombre rol_nombre
      ,usu.[fecharegistro]
      ,usu.[fechaupdated]
      ,usu.[estado]
FROM [usuario] usu
left join usuariolocal usulocal on usulocal.usuario_id = usu.id
left join local loc on loc.id = usulocal.local_id
left join rolusuario rlu on rlu.usuario_id =  usu.id
left join rol rl on rl.id = rlu.rol_id
                    where usu.id=@id";
            return await db.QueryFirstOrDefaultAsync<usuario>(sql, new { id = id });
        }

        public async Task<usuario> GetDetalleUsuarioxNombre(string nombre)
        {
            var db = _context.CreateConnection();
            var sql = @"SELECT [id]
      ,[nombre]
      ,[password]
      ,[fecharegistro]
      ,[fechaupdated]
      ,[estado]
  FROM [usuario]
                    where nombre=@nombre 
                    order by id asc";
            return await db.QueryFirstOrDefaultAsync<usuario>(sql, new { nombre = nombre });
        }

        public async Task<usuario> GetDetalleUsuarioCaja(Int64 caja_id,Int64 usuario_id)
        {
            var db = _context.CreateConnection();
            var sql = @"SELECT [id]
      ,[usuario_id]
      ,[caja_id]
      ,[fecharegistro]
      ,[estado]
         FROM  cajausuario   where caja_id=@caja_id and usuario_id=@usuario_id";
            return await db.QueryFirstOrDefaultAsync<usuario>(sql, new { caja_id = caja_id, usuario_id= usuario_id });
        }


        public async Task<Int64> CreateUsuario(usuario usuario)
        {
            var db = _context.CreateConnection();
            var sql = @"INSERT INTO [usuario]
           ([nombre],[password],[fecharegistro],[estado])
     VALUES
        (@nombre,@password,@fecharegistro,@estado) SELECT SCOPE_IDENTITY()";
            var result = await db.QueryAsync<Int64>(sql, usuario);
            return result.Single();
        }

        public async Task<bool> UpdateUsuario(usuario usuario)
        {
            var db = _context.CreateConnection();
            var sql = @"UPDATE  usuario
           set 
           nombre=@nombre
           ,fechaupdated =@fechaupdated
           ,estado=@estado where id=@id";
            var result = await db.ExecuteAsync(
                    sql, usuario);
            return result > 0;
        }
       
        public async Task<bool> CreateUsuarioCaja(usuarioCajaNuevo_ caja)
        {
            var db = _context.CreateConnection();
            var sql = @"INSERT INTO [cajausuario]
           ([usuario_id],[caja_id],[fecharegistro],[estado])
     VALUES
(@usuario_id,@caja_id,@fecharegistro,@estado)";
            var result = await db.ExecuteAsync(
                    sql, caja);
            return result > 0;
        }

        public async Task<bool> UpdateUsuarioCaja(usuarioCaja usuario)
        {
            var db = _context.CreateConnection();
            var sql = @"UPDATE  cajausuario
           set caja_id=@caja_id
           ,usuario_id=@usuario_id where id=@usuariocaja_id";
            var result = await db.ExecuteAsync(
                    sql, usuario);
            return result > 0;
        }

        public async Task<bool> DelteUsuarioCaja(Int64 id)
        {
            var db = _context.CreateConnection();
            var sql = @"delete from  cajausuario  where id=@id";
            var result = await db.ExecuteAsync(
                    sql, new {id=id});
            return result > 0;
        }

        public async Task<bool> CreateUsuarioLocal(usuarioLocal caja)
        {
            var db = _context.CreateConnection();
            var sql = @"INSERT INTO [usuariolocal]
           ([usuario_id],[local_id],[fecharegistro],[estado])
     VALUES
(@usuario_id,@local_id,@fecharegistro,@estado)";
            var result = await db.ExecuteAsync(
                    sql, caja);
            return result > 0;
        }

        public async Task<bool> UpdateUsuarioLocal(usuarioLocal usuario)
        {
            var db = _context.CreateConnection();
            var sql = @"UPDATE  usuariolocal
           set local_id=@local_id
           where id=@usuariolocal_id";
            var result = await db.ExecuteAsync(
                    sql, usuario);
            return result > 0;
        }

        public async Task<bool> CreateUsuarioRol(usuarioRol usurol)
        {
            var db = _context.CreateConnection();
            var sql = @"INSERT INTO [rolusuario]
           ([rol_id],[usuario_id],[fecharegistro])
     VALUES
(@rol_id,@usuario_id,@fecharegistro)";
            var result = await db.ExecuteAsync(
                    sql, usurol);
            return result > 0;
        }

        public async Task<bool> UpdateUsuarioRol(usuarioRol usuario)
        {
            var db = _context.CreateConnection();
            var sql = @"UPDATE  rolusuario
           set rol_id=@rol_id
            where id=@usuariorol_id";
            var result = await db.ExecuteAsync(
                    sql, usuario);
            return result > 0;
        }
    }
}

