using TrabajoFinal.Models;

namespace TrabajoFinal.Servicios
{
    public interface ITemporalVenta
    {
        void add(TemporalVenta temporalVenta);
        void Remove(TemporalVenta temporalVenta);
        IEnumerable<TemporalVenta> GetAllTemporarySales();
        IEnumerable<TemporalVenta> RemoveProduct(string id);
        TemporalVenta edit(string codigo);
        void editDetails(TemporalVenta obj);
        bool Exists(string codigo);
        IEnumerable<TemporalVenta> VaciarLista();
    }
}
