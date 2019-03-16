using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.General
{
    public class Subasta_Data
    {
        public List<Subasta_Info> GetList()
        {
            try
            {
                List<Subasta_Info> Lista;
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Lista = db.Subasta.Select(q => new Subasta_Info
                    {
                        IdProducto = q.IdProducto,
                        IdSubasta = q.IdSubasta,
                        IdUsuario = q.IdUsuario,
                        su_Cantidad = q.su_Cantidad,
                        su_Descripcion = q.su_Descripcion,
                        su_Estado = q.su_Estado,
                        su_EstadoCierre = q.su_EstadoCierre,
                        su_FechaFin = q.su_FechaFin,
                        su_Observacion = q.su_Observacion
                        
                    }).ToList();

                }
                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Subasta_Info GetInfo (decimal IdSubasta)
        {
            try
            {
                Subasta_Info info = new Subasta_Info();
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Subasta Entity = db.Subasta.Where(q => q.IdSubasta == IdSubasta).FirstOrDefault();
                    if (Entity == null) return null;
                    info = new Subasta_Info
                    {
                        IdProducto = Entity.IdProducto,
                        IdSubasta = Entity.IdSubasta,
                        IdUsuario = Entity.IdUsuario,
                        su_Cantidad = Entity.su_Cantidad,
                        su_Descripcion = Entity.su_Descripcion,
                        su_Estado = Entity.su_Estado,
                        su_EstadoCierre = Entity.su_EstadoCierre,
                        su_FechaFin = Entity.su_FechaFin,
                        su_Observacion = Entity.su_Observacion
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
                    var lst = from q in db.Subasta
                              select q;
                    if (lst.Count() > 0)
                        Id = lst.Max(q => q.IdSubasta) + 1;
                }
                return Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardarDB(Subasta_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    db.Subasta.Add(new Subasta
                    {
                        IdProducto = info.IdProducto,
                        IdSubasta = info.IdSubasta=GetId(),
                        IdUsuario = info.IdUsuario,
                        su_Cantidad = info.su_Cantidad,
                        su_Descripcion = info.su_Descripcion,
                        su_Estado = true,
                        su_EstadoCierre = info.su_EstadoCierre,
                        su_FechaFin = info.su_FechaFin,
                        su_Observacion = info.su_Observacion
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

        public bool ModificarDB(Subasta_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Subasta Entity = db.Subasta.Where(q => q.IdSubasta == info.IdSubasta).FirstOrDefault();
                    if (Entity == null) return false;
                    Entity.IdProducto = info.IdProducto;
                    Entity.IdUsuario = info.IdUsuario;
                    Entity.su_Cantidad = info.su_Cantidad;
                    Entity.su_Descripcion = info.su_Descripcion;
                    Entity.su_EstadoCierre = info.su_EstadoCierre;
                    Entity.su_FechaFin = info.su_FechaFin;
                    Entity.su_Observacion = info.su_Observacion;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AnularDB(Subasta_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Subasta Entity = db.Subasta.Where(q => q.IdSubasta == info.IdSubasta).FirstOrDefault();
                    if (Entity == null) return false;
                    Entity.su_Estado = false;
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
