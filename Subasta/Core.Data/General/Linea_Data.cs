using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.General
{
   public  class Linea_Data
    {
        public List<Linea_Info> GetList(int IdCategoria, bool mostrar_anulados)
        {
            try
            {
                List<Linea_Info> Lista;
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    if(mostrar_anulados)
                    {
                        Lista = db.Linea.Where(q => q.IdCategoria == IdCategoria).Select(q => new Linea_Info
                        {
                            IdLinea = q.IdLinea,
                            IdCategoria = q.IdCategoria,
                            li_Codigo = q.li_Codigo,
                            li_Descripcion = q.li_Descripcion,
                            li_Estado = q.li_Estado
                        }).ToList();
                    }
                    else
                    {
                        Lista = db.Linea.Where(q => q.IdCategoria == IdCategoria && q.li_Estado == true).Select(q => new Linea_Info
                        {
                            IdLinea = q.IdLinea,
                            IdCategoria = q.IdCategoria,
                            li_Codigo = q.li_Codigo,
                            li_Descripcion = q.li_Descripcion,
                            li_Estado = q.li_Estado
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

        public Linea_Info GetInfo(int IdCategoria, int IdLinea)
        {
            try
            {
                Linea_Info info = new Linea_Info();
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Linea Entity = db.Linea.Where(q => q.IdCategoria == IdCategoria && q.IdLinea == IdLinea).FirstOrDefault();
                    if (Entity == null) return null;
                    info = new Linea_Info
                    {
                        IdLinea = Entity.IdLinea,
                        IdCategoria = Entity.IdCategoria,
                        li_Codigo = Entity.li_Codigo,
                        li_Descripcion = Entity.li_Descripcion,
                        li_Estado = Entity.li_Estado
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
                    var lst = from q in db.Linea                              
                              select q;
                    if (lst.Count() > 0)
                        Id = lst.Max(q => q.IdLinea) + 1;
                }
                return Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardarDB(Linea_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    db.Linea.Add(new Linea
                    {
                        IdLinea = info.IdLinea=GetId(),
                        IdCategoria = info.IdCategoria,
                        li_Codigo = info.li_Codigo,
                        li_Descripcion = info.li_Descripcion,
                        li_Estado = true
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

        public bool ModificarDB(Linea_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Linea Entity = db.Linea.Where(q => q.IdCategoria == info.IdCategoria && q.IdLinea == info.IdLinea).FirstOrDefault();
                    if (Entity == null) return false;
                    Entity.li_Codigo = info.li_Codigo;
                    Entity.li_Descripcion = info.li_Descripcion;
                    db.SaveChanges();

                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AnularDB(Linea_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Linea Entity = db.Linea.Where(q => q.IdCategoria == info.IdCategoria && q.IdLinea == info.IdLinea).FirstOrDefault();
                    if (Entity == null) return false;
                    Entity.li_Estado = false;
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
