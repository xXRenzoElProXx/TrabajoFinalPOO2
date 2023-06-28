using TrabajoFinal.Models;

namespace TrabajoFinal.Servicios
{
    public interface ISnacks
    {
        IEnumerable<TbSnack> GellAllProducts();
        TbSnack GetProducto(string id);
        void add(TbSnack obj);
        void remove(string id);
        TbSnack edit(string id);
        void editDetails(TbSnack obj);
        List<TbSnack> filtrarPrecio(int precio1, int precio2);
    }
}