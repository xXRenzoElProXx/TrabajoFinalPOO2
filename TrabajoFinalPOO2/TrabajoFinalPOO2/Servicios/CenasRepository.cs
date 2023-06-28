using TrabajoFinal.Models;

namespace TrabajoFinal.Servicios
{
    public class CenasRepository : ICenas
    {
        TrabajofinalContext conexion = new TrabajofinalContext();

        public void add(TbCena obj)
        {
            conexion.TbCenas.Add(obj);
            conexion.SaveChanges();
        }

        public TbCena edit(string id)
        {
            var obj = (from tprod in conexion.TbCenas
                       where tprod.CodPro == id
                       select tprod).Single();
            return obj;
        }

        public void editDetails(TbCena obj)
        {
            var objAModificar =
                       (from tpro in conexion.TbCenas
                        where tpro.CodPro == obj.CodPro
                        select tpro).Single();
            objAModificar.DesPro = obj.DesPro;
            objAModificar.PrePro = obj.PrePro;
            objAModificar.StkAct = obj.StkAct;
            objAModificar.Img = obj.Img;
            conexion.SaveChanges();
        }

        public List<TbCena> filtrarPrecio(int precio1, int precio2)
        {
            var objProducto =
                            (from tpro in conexion.TbCenas
                             where tpro.PrePro < precio2 && tpro.PrePro > precio1
                             select tpro).ToList();

            return objProducto;
        }

        public IEnumerable<TbCena> GellAllProducts()
        {
            return conexion.TbCenas;
        }

        public TbCena GetProducto(string id)
        {
            var objProducto =
                (from tpro in conexion.TbCenas  
                 where tpro.CodPro == id
                 select tpro).Single();
                  
            return objProducto;
        }

        public void remove(string id)
        {
            var obj = (from tbPro in conexion.TbCenas
                       where tbPro.CodPro == id
                       select tbPro).Single();
            conexion.Remove(obj);
            conexion.SaveChanges();
        }
    }
}
