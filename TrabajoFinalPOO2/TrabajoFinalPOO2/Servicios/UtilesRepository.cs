﻿using TrabajoFinal.Models;

namespace TrabajoFinal.Servicios
{
    public class UtilesRepository : IUtiles
    {
        TrabajofinalContext conexion = new TrabajofinalContext();

        public void add(TbUtile obj)
        {
            conexion.TbUtiles.Add(obj);
            conexion.SaveChanges();
        }

        public TbUtile edit(string id)
        {
            var obj = (from tprod in conexion.TbUtiles
                       where tprod.CodPro == id
                       select tprod).Single();
            return obj;
        }

        public void editDetails(TbUtile obj)
        {
            var objAModificar =
                       (from tpro in conexion.TbUtiles
                        where tpro.CodPro == obj.CodPro
                        select tpro).Single();
            objAModificar.DesPro = obj.DesPro;
            objAModificar.PrePro = obj.PrePro;
            objAModificar.StkAct = obj.StkAct;
            objAModificar.Img = obj.Img;
            conexion.SaveChanges();
        }

        public List<TbUtile> filtrarPrecio(int precio1, int precio2)
        {
            var objProducto =
                            (from tpro in conexion.TbUtiles
                             where tpro.PrePro < precio2 && tpro.PrePro > precio1
                             select tpro).ToList();

            return objProducto;
        }

        public IEnumerable<TbUtile> GellAllProducts()
        {
            return conexion.TbUtiles;
        }

        public TbUtile GetProducto(string id)
        {
            var objProducto =
                (from tpro in conexion.TbUtiles
                 where tpro.CodPro == id
                 select tpro).Single();
                  
            return objProducto;
        }

        public void remove(string id)
        {
            var obj = (from tbPro in conexion.TbUtiles
                       where tbPro.CodPro == id
                       select tbPro).Single();
            conexion.Remove(obj);
            conexion.SaveChanges();
        }
    }
}
