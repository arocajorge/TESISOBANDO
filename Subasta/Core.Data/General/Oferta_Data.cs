using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.General
{
   public class Oferta_Data
    {
        public List<Oferta_Info> GetList(bool mostrar_anulados)
        {
            try
            {
                List<Oferta_Info> Lista;
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    if(mostrar_anulados)
                    {
                        Lista = db.Oferta.Select(q => new Oferta_Info
                        {
                            IdOferta = q.IdOferta,
                            IdProveedor = q.IdProveedor,
                            IdSubasta = q.IdSubasta,
                            of_Observacion = q.of_Observacion,
                            of_Plazo = q.of_Plazo,
                            of_Total = q.of_Total
                        }).ToList();
                    }
                    else
                    {
                        Lista = db.Oferta.Where(q => q.of_Estado == true).Select(q => new Oferta_Info
                        {
                            IdOferta = q.IdOferta,
                            IdProveedor = q.IdProveedor,
                            IdSubasta = q.IdSubasta,
                            of_Observacion = q.of_Observacion,
                            of_Plazo = q.of_Plazo,
                            of_Total = q.of_Total
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

        public List<Oferta_Info> GetList(decimal IdSubasta)
        {
            try
            {
                List<Oferta_Info> Lista;
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Lista = (from q in db.Oferta
                             join p in db.Proveedor
                             on q.IdProveedor equals p.IdProveedor
                             where q.of_Estado == true && q.IdSubasta == IdSubasta
                             select new Oferta_Info
                             {
                                 IdOferta = q.IdOferta,
                                 IdProveedor = q.IdProveedor,
                                 IdSubasta = q.IdSubasta,
                                 of_Observacion = q.of_Observacion,
                                 of_Plazo = q.of_Plazo,
                                 of_Total = q.of_Total,
                                 pv_Descripcion = p.pv_Descripcion
                             }).ToList();
                }
                return Lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Oferta_Info GetInfo(decimal IdOferta)
        {
            try
            {
                Oferta_Info info = new Oferta_Info();
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Oferta Entity = db.Oferta.Where(q => q.IdOferta == IdOferta).FirstOrDefault();
                    if (Entity == null) return null;

                    info = new Oferta_Info
                    {
                        IdProveedor = Entity.IdProveedor,
                        IdOferta = Entity.IdOferta,
                        IdSubasta = Entity.IdSubasta,
                        of_Estado = Entity.of_Estado,
                        of_EstadoGanador = Entity.of_EstadoGanador,
                        of_Fecha = Entity.of_Fecha,
                        of_FechaFin = Entity.of_FechaFin,
                        of_Observacion = Entity.of_Observacion,
                        of_Plazo = Entity.of_Plazo,
                        of_Total = Entity.of_Total
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
                    var lst = from q in db.Oferta
                              select q;
                    if (lst.Count() > 0)
                        Id= lst.Max(q => q.IdOferta) + 1;
                }
                return Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardarDB(Oferta_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    db.Oferta.Add(new Oferta
                    {
                        IdProveedor = info.IdProveedor,
                        IdOferta = info.IdOferta=GetId(),
                        IdSubasta = info.IdSubasta,
                        of_Estado = true,
                        of_EstadoGanador = info.of_EstadoGanador,
                        of_Fecha = info.of_Fecha,
                        of_FechaFin = info.of_FechaFin,
                        of_Observacion = info.of_Observacion,
                        of_Plazo = info.of_Plazo,
                        of_Total = info.of_Total
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

        public bool ModificarDB(Oferta_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Oferta Entity = db.Oferta.Where(q => q.IdOferta == info.IdOferta).FirstOrDefault();
                    if (Entity == null)
                    {
                        Entity = db.Oferta.Where(q => q.IdSubasta == info.IdSubasta && q.IdProveedor == info.IdProveedor).FirstOrDefault();
                        if (Entity == null)
                        {
                            return GuardarDB(info);
                        }
                    }
                    Entity.of_Fecha = info.of_Fecha;
                    Entity.of_FechaFin = info.of_FechaFin;
                    Entity.of_Observacion = info.of_Observacion;
                    Entity.of_Plazo = info.of_Plazo;
                    Entity.of_Total = info.of_Total;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AnularDB(Oferta_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Oferta Entity = db.Oferta.Where(q => q.IdOferta == info.IdOferta).FirstOrDefault();
                    if (Entity == null) return false;
                    Entity.of_Estado = false;
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
