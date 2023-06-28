using TrabajoFinal.Models;

namespace TrabajoFinal.Servicios
{
    public interface ICenas
    {
        IEnumerable<TbCena> GellAllProducts();
        TbCena GetProducto(string id);
        void add(TbCena obj);
        void remove(string id);
        TbCena edit(string id);
        void editDetails(TbCena obj);
        List<TbCena> filtrarPrecio(int precio1, int precio2);
    }
}