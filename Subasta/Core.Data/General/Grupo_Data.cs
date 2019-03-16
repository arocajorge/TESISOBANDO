using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.General
{
   public class Grupo_Data
    {
        public List<Grupo_Info> GetList(int IdLinea, bool mostrar_anulados)
        {
            try
            {
                List<Grupo_Info> Lista;
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    if(mostrar_anulados)
                    {
                        Lista = db.Grupo.Where(q => q.IdLinea == IdLinea).Select(q => new Grupo_Info
                        {
                            IdLinea = q.IdLinea,
                            IdGrupo = q.IdGrupo,
                            gr_Codigo = q.gr_Codigo,
                            gr_Descripcion = q.gr_Descripcion,
                            gr_Estado = q.gr_Estado
                        }).ToList();
                    }
                    else
                    {
                        Lista = db.Grupo.Where(q => q.IdLinea == IdLinea && q.gr_Estado == true).Select(q => new Grupo_Info
                        {
                            IdLinea = q.IdLinea,
                            IdGrupo = q.IdGrupo,
                            gr_Codigo = q.gr_Codigo,
                            gr_Descripcion = q.gr_Descripcion,
                            gr_Estado = q.gr_Estado

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

        public Grupo_Info GetInfo(int IdLinea, int IdGrupo)
        {
            try
            {
                Grupo_Info info = new Grupo_Info();
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Grupo Entity = db.Grupo.Where(q => q.IdLinea == IdLinea && q.IdGrupo == IdGrupo).FirstOrDefault();
                    if (Entity == null) return null;
                    info = new Grupo_Info
                    {
                        IdLinea = Entity.IdLinea,
                        IdGrupo = Entity.IdGrupo,
                        gr_Codigo = Entity.gr_Codigo,
                        gr_Descripcion = Entity.gr_Descripcion,
                        gr_Estado = Entity.gr_Estado,

                        IdCategoria = Entity.Linea.IdCategoria
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
                    var lst = from q in db.Grupo                              
                              select q;
                    if (lst.Count() > 0)
                        Id = lst.Max(q => q.IdGrupo) + 1;
                }
                return Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardarDB(Grupo_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    db.Grupo.Add(new Grupo
                    {
                        IdLinea = info.IdLinea,
                        IdGrupo = info.IdGrupo=GetId(),
                        gr_Codigo = info.gr_Codigo,
                        gr_Descripcion = info.gr_Descripcion,
                        gr_Estado = true

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

        public bool ModificarDB(Grupo_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Grupo Entity = db.Grupo.Where(q => q.IdLinea == info.IdLinea && q.IdGrupo == info.IdGrupo).FirstOrDefault();
                    if (Entity == null) return false;

                    Entity.gr_Codigo = info.gr_Codigo;
                    Entity.gr_Descripcion = info.gr_Descripcion;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AnularDB(Grupo_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Grupo Entity = db.Grupo.Where(q => q.IdLinea == info.IdLinea && q.IdGrupo == info.IdGrupo).FirstOrDefault();
                    if (Entity == null) return false;

                    Entity.gr_Estado = false;
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
