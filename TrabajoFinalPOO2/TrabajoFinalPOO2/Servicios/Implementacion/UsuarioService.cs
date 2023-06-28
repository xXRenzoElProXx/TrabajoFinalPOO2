using Microsoft.EntityFrameworkCore;
using TrabajoFinal.Models;
using TrabajoFinal.Servicios.Contrato;

namespace TrabajoFinal.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private List<Usuario> lst = new List<Usuario>();
        private readonly TrabajofinalContext _dbContext;
        public UsuarioService(TrabajofinalContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void cambiarPass(Usuario obj)
        {
            var objAModificar =
                       (from tpro in _dbContext.Usuarios
                        where tpro.IdUsuario == obj.IdUsuario
                        select tpro).Single();
            objAModificar.Clave = obj.Clave;
            _dbContext.SaveChanges();
        }
        public Usuario changeP(int id)
        {
            var obj = (from tprod in _dbContext.Usuarios
                       where tprod.IdUsuario == id
                       select tprod).Single();
            return obj;
        }
        public Usuario edit(int id)
        {
            var obj = (from tprod in _dbContext.Usuarios
                       where tprod.IdUsuario == id
                       select tprod).Single();
            return obj;
        }
        public void editDetails(Usuario obj)
        {
            var objAModificar =
                       (from tpro in _dbContext.Usuarios
                        where tpro.IdUsuario == obj.IdUsuario
                        select tpro).Single();
            objAModificar.NombreUsuario = obj.NombreUsuario;
            objAModificar.Imagen = obj.Imagen;
            objAModificar.Clave = obj.Clave;
            _dbContext.SaveChanges();
        }
        public bool Exists(string correo)
        {
            return lst.Any(item => item.Correo == correo);
        }
        public async Task<Usuario> GetUsuario(string correo, string clave)
        {
            Usuario usuario_encontrado = await _dbContext.Usuarios.Where(u => u.Correo == correo && u.Clave == clave)
                 .FirstOrDefaultAsync();

            return usuario_encontrado;
        }
        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _dbContext.Usuarios.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}