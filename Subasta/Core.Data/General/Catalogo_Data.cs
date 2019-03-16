using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.General
{
    public class Catalogo_Data
    {
        public List<Catalogo_Info> GetList(int IdCatalogoTipo , bool mostrar_anulados)
        {
            try
            {
                List<Catalogo_Info> Lista;
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    if(mostrar_anulados)
                    {
                        Lista = db.Catalogo.Where(q => q.IdCatalogoTipo == IdCatalogoTipo).Select(q => new Catalogo_Info
                        {
                            IdCatalogoTipo = q.IdCatalogoTipo,
                            IdCatalogo = q.IdCatalogo,
                            ct_Descripcion = q.ct_Descripcion,
                            Estado = q.Estado

                        }).ToList();
                    }
                    else
                    {
                        Lista = db.Catalogo.Where(q => q.IdCatalogoTipo == IdCatalogoTipo && q.Estado == true).Select(q => new Catalogo_Info
                        {
                            IdCatalogoTipo = q.IdCatalogoTipo,
                            IdCatalogo = q.IdCatalogo,
                            ct_Descripcion = q.ct_Descripcion,
                            Estado = q.Estado

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

        public Catalogo_Info GetInfo(int IdCatalogoTipo, int IdCatalogo)
        {
            try
            {
                Catalogo_Info info = new Catalogo_Info();
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Catalogo Entity = db.Catalogo.Where(q =>q.IdCatalogoTipo == IdCatalogoTipo && q.IdCatalogo == IdCatalogo).FirstOrDefault();
                    if (Entity == null) return null;
                    info = new Catalogo_Info
                    {
                        IdCatalogo = Entity.IdCatalogo,
                        IdCatalogoTipo = Entity.IdCatalogoTipo,
                        ct_Descripcion = Entity.ct_Descripcion,
                        Estado = Entity.Estado
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
                    var lst = from q in db.Catalogo
                              select q;
                    if (lst.Count() > 0)
                        Id = lst.Max(q => q.IdCatalogo) + 1;
                }
                return Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardarDB(Catalogo_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    db.Catalogo.Add(new Catalogo
                    {
                        IdCatalogoTipo = info.IdCatalogoTipo = GetId(),
                        ct_Descripcion = info.ct_Descripcion,
                        IdCatalogo = info.IdCatalogo,
                        Estado = true
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

        public bool ModificarDB(Catalogo_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Catalogo Entity = db.Catalogo.Where(q => q.IdCatalogoTipo == info.IdCatalogoTipo && q.IdCatalogo == info.IdCatalogo).FirstOrDefault();
                    if (Entity == null) return false;
                    Entity.ct_Descripcion = info.ct_Descripcion;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AnularDB(Catalogo_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Catalogo Entity = db.Catalogo.Where(q => q.IdCatalogoTipo == info.IdCatalogoTipo && q.IdCatalogo == info.IdCatalogo).FirstOrDefault();
                    if (Entity == null) return false;
                    Entity.Estado = false;
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
