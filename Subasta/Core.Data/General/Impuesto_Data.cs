using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.General
{
    public class Impuesto_Data
    {
        public List<Impuesto_Info> GetList(bool mostrar_anulados)
        {
            try
            {
                List<Impuesto_Info> Lista;
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    if (mostrar_anulados)
                    {
                        Lista = db.Impuesto.Select(q => new Impuesto_Info
                        {
                            IdImpuesto = q.IdImpuesto,
                            im_Descripcion = q.im_Descripcion,
                            im_Estado = q.im_Estado,
                            im_Porcentaje = q.im_Porcentaje
                        }).ToList();
                    }
                    else
                    {
                        Lista = db.Impuesto.Where(q=>q.im_Estado == true).Select(q => new Impuesto_Info
                        {
                            IdImpuesto = q.IdImpuesto,
                            im_Descripcion = q.im_Descripcion,
                            im_Estado = q.im_Estado,
                            im_Porcentaje = q.im_Porcentaje
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

        public Impuesto_Info GetInfo(int IdImpuesto)
        {
            try
            {
                Impuesto_Info info = new Impuesto_Info();
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Impuesto Entity = db.Impuesto.Where(q => q.IdImpuesto == IdImpuesto).FirstOrDefault();
                    if (Entity == null) return null;
                    info = new Impuesto_Info
                    {
                        IdImpuesto = Entity.IdImpuesto,
                        im_Descripcion = Entity.im_Descripcion,
                        im_Estado = Entity.im_Estado,
                        im_Porcentaje = Entity.im_Porcentaje
                    };
                }
                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private int GetId()
        {
            try
            {
                int Id = 1;
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    var lst = from q in db.Impuesto
                              select q;
                    if (lst.Count() > 0)
                        Id = lst.Max(q => q.IdImpuesto) + 1;
                }
                return Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardarDB(Impuesto_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    db.Impuesto.Add(new Impuesto
                    {

                        IdImpuesto = info.IdImpuesto=GetId(),
                        im_Descripcion = info.im_Descripcion,
                        im_Estado = true,
                        im_Porcentaje = info.im_Porcentaje
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

        public bool ModificarDB(Impuesto_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Impuesto Entity = db.Impuesto.Where(q => q.IdImpuesto == info.IdImpuesto).FirstOrDefault();
                    if (Entity == null) return false;

                    Entity.im_Descripcion = info.im_Descripcion;
                    Entity.im_Porcentaje = info.im_Porcentaje;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AnularDB(Impuesto_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Impuesto Entity = db.Impuesto.Where(q => q.IdImpuesto == info.IdImpuesto).FirstOrDefault();
                    if (Entity == null) return false;

                    Entity.im_Estado = false;
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
