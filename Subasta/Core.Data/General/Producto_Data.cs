using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.General
{
   public class Producto_Data
    {
        public List<Producto_Info> GetList(bool mostrar_anulados)
        {
            try
            {
                List<Producto_Info> Lista;
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                   if(mostrar_anulados)
                    {
                        Lista = db.Producto.Select(q => new Producto_Info
                        {
                            IdProducto = q.IdProducto,
                            pr_Descripcion = q.pr_Descripcion,
                            pr_Observacion = q.pr_Observacion,
                            IdCatalogoMarca = q.IdCatalogoMarca,
                            IdCatalogoModelo = q.IdCatalogoModelo,
                            IdCatalogoTipo = q.IdCatalogoTipo,
                            IdGrupo = q.IdGrupo,
                            IdImpuestoIva = q.IdImpuestoIva,
                            pr_Codigo = q.pr_Codigo,
                            pr_Estado = q.pr_Estado
                        }).ToList();
                    }
                    else
                    {
                        Lista = db.Producto.Where(q=>q.pr_Estado == true).Select(q => new Producto_Info
                        {
                            IdProducto = q.IdProducto,
                            pr_Descripcion = q.pr_Descripcion,
                            pr_Observacion = q.pr_Observacion,
                            IdCatalogoMarca = q.IdCatalogoMarca,
                            IdCatalogoModelo = q.IdCatalogoModelo,
                            IdCatalogoTipo = q.IdCatalogoTipo,
                            IdGrupo = q.IdGrupo,
                            IdImpuestoIva = q.IdImpuestoIva,
                            pr_Codigo = q.pr_Codigo,
                            pr_Estado = q.pr_Estado
                        }).ToList();
                    }
                }
                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Producto_Info GetInfo(decimal IdProducto)
        {
            try
            {
                Producto_Info info = new Producto_Info();
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Producto Entity = db.Producto.Where(q => q.IdProducto == IdProducto).FirstOrDefault();
                    if (Entity == null) return null;
                    info = new Producto_Info
                    {
                        IdProducto = Entity.IdProducto,
                        pr_Descripcion = Entity.pr_Descripcion,
                        pr_Observacion = Entity.pr_Observacion,
                        IdCatalogoMarca = Entity.IdCatalogoMarca,
                        IdCatalogoModelo = Entity.IdCatalogoModelo,
                        IdCatalogoTipo = Entity.IdCatalogoTipo,
                        IdGrupo = Entity.IdGrupo,
                        IdImpuestoIva = Entity.IdImpuestoIva,
                        pr_Codigo = Entity.pr_Codigo,
                        pr_Estado = Entity.pr_Estado
                    };
                }
                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private decimal GetId()
        {
            try
            {
                decimal Id = 1;
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    var lst = from q in db.Producto
                              select q;
                    if (lst.Count() > 0)
                        Id = lst.Max(q => q.IdProducto) + 1;
                }
                return Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardarDB(Producto_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    db.Producto.Add(new Producto
                    {

                        IdProducto = info.IdProducto=GetId(),
                        pr_Descripcion = info.pr_Descripcion,
                        pr_Observacion = info.pr_Observacion,
                        IdCatalogoMarca = info.IdCatalogoMarca,
                        IdCatalogoModelo = info.IdCatalogoModelo,
                        IdCatalogoTipo = info.IdCatalogoTipo,
                        IdGrupo = info.IdGrupo,
                        IdImpuestoIva = info.IdImpuestoIva,
                        pr_Codigo = info.pr_Codigo,
                        pr_Estado = true
                    });
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ModificarDB(Producto_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Producto Entity = db.Producto.Where(q => q.IdProducto == info.IdProducto).FirstOrDefault();
                    if (Entity == null) return false;

                    Entity.pr_Descripcion = info.pr_Descripcion;
                    Entity.pr_Observacion = info.pr_Observacion;
                    Entity.IdCatalogoMarca = info.IdCatalogoMarca;
                    Entity.IdCatalogoModelo = info.IdCatalogoModelo;
                    Entity.IdCatalogoTipo = info.IdCatalogoTipo;
                    Entity.IdGrupo = info.IdGrupo;
                    Entity.IdImpuestoIva = info.IdImpuestoIva;
                    Entity.pr_Codigo = info.pr_Codigo;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AnularDB(Producto_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Producto Entity = db.Producto.Where(q => q.IdProducto == info.IdProducto).FirstOrDefault();
                    if (Entity == null) return false;

                    Entity.pr_Estado = false;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
