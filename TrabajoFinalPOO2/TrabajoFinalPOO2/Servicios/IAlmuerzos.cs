using TrabajoFinal.Models;

namespace TrabajoFinal.Servicios
{
    public interface IAlmuerzos
    {
        IEnumerable<TbAlmuerzo> GellAllProducts();
        TbAlmuerzo GetProducto(string id);
        void add(TbAlmuerzo obj);
        void remove(string id);
        TbAlmuerzo edit(string id);
        void editDetails(TbAlmuerzo obj);
        List<TbAlmuerzo> filtrarPrecio(int precio1, int precio2);
    }
}