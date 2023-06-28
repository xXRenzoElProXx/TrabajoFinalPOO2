using System.Collections.Generic;
using TrabajoFinal.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrabajoFinal.Servicios
{
    public class TemporalVentaRepository : ITemporalVenta
    {
        private List<TemporalVenta> lst = new List<TemporalVenta>();   
        public void add(TemporalVenta temporalVenta)
        {
            lst.Add(temporalVenta);
        }
        public TemporalVenta edit(string codigo)
        {
            var obj = (from tprod in lst
                       where tprod.codigo == codigo
                       select tprod).Single();
            return obj;
        }
        public void editDetails(TemporalVenta obj)
        {
            var objAModificar =
                       (from tpro in lst
                        where tpro.codigo == obj.codigo
                        select tpro).Single();
            objAModificar.cantidad = obj.cantidad;
            objAModificar.total = obj.cantidad * objAModificar.precio;
        }
        public bool Exists(string codigo)
        {
            return lst.Any(item => item.codigo == codigo);
        }
        public IEnumerable<TemporalVenta> GetAllTemporarySales()
        {
            return lst;
        }
        public void Remove(TemporalVenta temporalVenta)
        {
            lst.Remove(temporalVenta);
        }
        public IEnumerable<TemporalVenta> RemoveProduct(string id)
        {
            var valuesToRemove = lst.Where(i => i.codigo == id).ToArray();
            foreach(var item in valuesToRemove)
            {
                lst.Remove(item);
            }
            return lst;
        }
        public IEnumerable<TemporalVenta> VaciarLista()
        {
            for (int i = lst.Count - 1; i >= 0; i--)
            {
                lst.Remove(lst[i]);
            }
            return lst;
        }
    }
}