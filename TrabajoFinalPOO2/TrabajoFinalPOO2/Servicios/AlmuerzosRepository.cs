using TrabajoFinal.Models;

namespace TrabajoFinal.Servicios
{
    public class AlmuerzosRepository : IAlmuerzos
    {
        TrabajofinalContext conexion = new TrabajofinalContext();

        public void add(TbAlmuerzo obj)
        {
            conexion.TbAlmuerzos.Add(obj);
            conexion.SaveChanges();
        }

        public TbAlmuerzo edit(string id)
        {
            var obj = (from tprod in conexion.TbAlmuerzos
                       where tprod.CodPro == id
                       select tprod).Single();
            return obj;
        }

        public void editDetails(TbAlmuerzo obj)
        {
            var objAModificar =
                       (from tpro in conexion.TbAlmuerzos
                        where tpro.CodPro == obj.CodPro
                        select tpro).Single();
            objAModificar.DesPro = obj.DesPro;
            objAModificar.PrePro = obj.PrePro;
            objAModificar.StkAct = obj.StkAct;
            objAModificar.Img = obj.Img;
            conexion.SaveChanges();
        }

        public List<TbAlmuerzo> filtrarPrecio(int precio1, int precio2)
        {
            var objProducto =
                            (from tpro in conexion.TbAlmuerzos
                             where tpro.PrePro < precio2 && tpro.PrePro > precio1
                             select tpro).ToList();

            return objProducto;
        }

        public IEnumerable<TbAlmuerzo> GellAllProducts()
        {
            return conexion.TbAlmuerzos;
        }

        public TbAlmuerzo GetProducto(string id)
        {
            var objProducto =
                (from tpro in conexion.TbAlmuerzos
                 where tpro.CodPro == id
                 select tpro).Single();
                  
            return objProducto;
        }

        public void remove(string id)
        {
            var obj = (from tbPro in conexion.TbAlmuerzos
                       where tbPro.CodPro == id
                       select tbPro).Single();
            conexion.Remove(obj);
            conexion.SaveChanges();
        }
    }
}