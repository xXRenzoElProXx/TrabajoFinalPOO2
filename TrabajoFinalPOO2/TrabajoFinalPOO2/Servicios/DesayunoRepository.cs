﻿using TrabajoFinal.Models;

namespace TrabajoFinal.Servicios
{
    public class DesayunoRepository : IDesayuno
    {
        TrabajofinalContext conexion = new TrabajofinalContext();
        public void add(TbDesayuno obj)
        {
            conexion.TbDesayunos.Add(obj);
            conexion.SaveChanges();
        }

        public TbDesayuno edit(string id)
        {
            var obj = (from tprod in conexion.TbDesayunos
                       where tprod.CodPro == id
                       select tprod).Single();
            return obj;
        }

        public void editDetails(TbDesayuno obj)
        {
            var objAModificar =
                       (from tpro in conexion.TbDesayunos
                        where tpro.CodPro == obj.CodPro
                        select tpro).Single();
            objAModificar.DesPro = obj.DesPro;
            objAModificar.PrePro = obj.PrePro;
            objAModificar.StkAct = obj.StkAct;
            objAModificar.Img = obj.Img;
            conexion.SaveChanges();
        }

        public List<TbDesayuno> filtrarPrecio(int precio1, int precio2)
        {
            var objProducto =
                            (from tpro in conexion.TbDesayunos
                             where tpro.PrePro < precio2 && tpro.PrePro > precio1
                             select tpro).ToList();

            return objProducto;
        }

        public IEnumerable<TbDesayuno> GellAllProducts()
        {
            return conexion.TbDesayunos;
        }

        public TbDesayuno GetProducto(string id)
        {
            var objProducto =
                (from tpro in conexion.TbDesayunos
                 where tpro.CodPro == id
                 select tpro).Single();
                  
            return objProducto;
        }

        public void remove(string id)
        {
            var obj = (from tbPro in conexion.TbDesayunos
                       where tbPro.CodPro == id
                       select tbPro).Single();
            conexion.Remove(obj);
            conexion.SaveChanges();
        }
    }
}
