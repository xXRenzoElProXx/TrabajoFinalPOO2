using TrabajoFinal.Models;

namespace TrabajoFinal.Servicios
{
    public interface IUtiles
    {
        IEnumerable<TbUtile> GellAllProducts();
        TbUtile GetProducto(string id);
        void add(TbUtile obj);
        void remove(string id);
        TbUtile edit(string id);
        void editDetails(TbUtile obj);
        List<TbUtile> filtrarPrecio(int precio1, int precio2);
    }
}