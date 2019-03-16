using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.General
{
    public class CatalogoTipo_Data
    {
        public List<CatalogoTipo_Info> GetList()
        {
            try
            {
                List<CatalogoTipo_Info> Lista;
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Lista = db.CatalogoTipo.Select(q => new CatalogoTipo_Info
                    {
                        IdCatalogoTipo = q.IdCatalogoTipo,
                        tc_Descripcion = q.tc_Descripcion
                    }).ToList();
                }
                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CatalogoTipo_Info GetInfo(int IdCatalogoTipo)
        {
            try
            {
                CatalogoTipo_Info info = new CatalogoTipo_Info();
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    CatalogoTipo Entity = db.CatalogoTipo.Where(q => q.IdCatalogoTipo == IdCatalogoTipo).FirstOrDefault();
                    if (Entity == null) return null;
                    info = new CatalogoTipo_Info
                    {
                        IdCatalogoTipo = Entity.IdCatalogoTipo,
                        tc_Descripcion = Entity.tc_Descripcion
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
                    var lst = from q in db.CatalogoTipo
                              select q;
                    if (lst.Count() > 0)
                        Id = lst.Max(q => q.IdCatalogoTipo) + 1;
                }
                return Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardarDB(CatalogoTipo_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    db.CatalogoTipo.Add(new CatalogoTipo
                    {
                        IdCatalogoTipo = info.IdCatalogoTipo=GetId(),
                        tc_Descripcion = info.tc_Descripcion
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

        public bool ModificarDB(CatalogoTipo_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    CatalogoTipo Entity = db.CatalogoTipo.Where(q => q.IdCatalogoTipo == info.IdCatalogoTipo).FirstOrDefault();
                    if (Entity == null) return false;
                    Entity.tc_Descripcion = info.tc_Descripcion;
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
