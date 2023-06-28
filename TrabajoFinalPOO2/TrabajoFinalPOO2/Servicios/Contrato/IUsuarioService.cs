using TrabajoFinal.Models;

namespace TrabajoFinal.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuario(string correo, string clave);
        Task<Usuario> SaveUsuario(Usuario modelo);
        Usuario edit(int id);
        void editDetails(Usuario obj);
        Usuario changeP(int id);
        void cambiarPass(Usuario obj);
        bool Exists(string correo);
    }
}
