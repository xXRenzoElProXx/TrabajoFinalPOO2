using TrabajoFinal.Models;

namespace TrabajoFinal.Servicios
{
    public interface IDesayuno
    {
        IEnumerable<TbDesayuno> GellAllProducts();
        TbDesayuno GetProducto(string id);
        void add(TbDesayuno obj);
        void remove(string id);
        TbDesayuno edit(string id);
        void editDetails(TbDesayuno obj);
        List<TbDesayuno> filtrarPrecio(int precio1, int precio2);
    }
}