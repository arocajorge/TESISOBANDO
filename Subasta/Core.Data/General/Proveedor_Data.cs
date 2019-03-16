using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.General
{
   public class Proveedor_Data
    {
        public List<Proveedor_Info> GetList(bool mostrar_Anulados)
        {
            try
            {
                List<Proveedor_Info> Lista;
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    if(mostrar_Anulados)
                    {
                        Lista = db.Proveedor.Select(q => new Proveedor_Info
                        {
                            IdProveedor = q.IdProveedor,
                            pv_CedulaRuc = q.pv_CedulaRuc,
                            pv_Codigo = q.pv_Codigo,
                            pv_Correo = q.pv_Correo,
                            pv_Descripcion = q.pv_Descripcion,
                            pv_Direccion = q.pv_Direccion,
                            pv_Estado = q.pv_Estado,
                            pv_Plazo = q.pv_Plazo,
                            pv_Telefono = q.pv_Telefono,
                            pv_TipoDoc = q.pv_TipoDoc
                        }).ToList();
                    }
                    else
                    {
                        Lista = db.Proveedor.Where(q=>q.pv_Estado == true).Select(q => new Proveedor_Info
                        {
                            IdProveedor = q.IdProveedor,
                            pv_CedulaRuc = q.pv_CedulaRuc,
                            pv_Codigo = q.pv_Codigo,
                            pv_Correo = q.pv_Correo,
                            pv_Descripcion = q.pv_Descripcion,
                            pv_Direccion = q.pv_Direccion,
                            pv_Estado = q.pv_Estado,
                            pv_Plazo = q.pv_Plazo,
                            pv_Telefono = q.pv_Telefono,
                            pv_TipoDoc = q.pv_TipoDoc
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

        public Proveedor_Info GetInfo(decimal IdProveedor)
        {
            try
            {
                Proveedor_Info info = new Proveedor_Info();
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Proveedor Entity = db.Proveedor.Where(q => q.IdProveedor == IdProveedor).FirstOrDefault();
                    if (Entity == null) return null;
                    info = new Proveedor_Info
                    {
                        IdProveedor = Entity.IdProveedor,
                        pv_CedulaRuc = Entity.pv_CedulaRuc,
                        pv_Codigo = Entity.pv_Codigo,
                        pv_Correo = Entity.pv_Correo,
                        pv_Descripcion = Entity.pv_Descripcion,
                        pv_Direccion = Entity.pv_Direccion,
                        pv_Estado = Entity.pv_Estado,
                        pv_Plazo = Entity.pv_Plazo,
                        pv_Telefono = Entity.pv_Telefono,
                        pv_TipoDoc = Entity.pv_TipoDoc
                    };
                }
                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private decimal GetID()
        {
            try
            {
                decimal Id = 1;

                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    var lst = from q in db.Proveedor
                              select q;
                    if (lst.Count() > 0)
                        Id = lst.Max(q => q.IdProveedor) + 1;
                }
                return Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardarDB(Proveedor_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    db.Proveedor.Add(new Proveedor
                    {
                        IdProveedor = info.IdProveedor=GetID(),
                        pv_CedulaRuc = info.pv_CedulaRuc,
                        pv_Codigo = info.pv_Codigo,
                        pv_Correo = info.pv_Correo,
                        pv_Descripcion = info.pv_Descripcion,
                        pv_Direccion = info.pv_Direccion,
                        pv_Estado = true,
                        pv_Plazo = info.pv_Plazo,
                        pv_Telefono = info.pv_Telefono,
                        pv_TipoDoc = info.pv_TipoDoc
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

        public bool ModificarDB(Proveedor_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Proveedor Entity = db.Proveedor.Where(q => q.IdProveedor == info.IdProveedor).FirstOrDefault();
                    if (Entity == null) return false;
                    Entity.pv_CedulaRuc = info.pv_CedulaRuc;
                    Entity.pv_Codigo = info.pv_Codigo;
                    Entity.pv_Correo = info.pv_Correo;
                    Entity.pv_Descripcion = info.pv_Descripcion;
                    Entity.pv_Direccion = info.pv_Direccion;
                    Entity.pv_Plazo = info.pv_Plazo;
                    Entity.pv_Telefono = info.pv_Telefono;
                    Entity.pv_TipoDoc = info.pv_TipoDoc;
                    db.SaveChanges();

                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AnularDB(Proveedor_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Proveedor Entity = db.Proveedor.Where(q => q.IdProveedor == info.IdProveedor).FirstOrDefault();
                    if (Entity == null) return false;
                    Entity.pv_Estado = false;
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
