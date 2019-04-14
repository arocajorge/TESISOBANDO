using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Data.General
{
    public class Usuario_Data
    {
        public List<Usuario_Info> GetList()
        {
            try
            {
                List<Usuario_Info> Lista = new List<Usuario_Info>();

                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Lista = db.Usuario.Select(q => new Usuario_Info
                    {
                        IdUsuario = q.IdUsuario,
                        us_Clave = q.us_Clave,
                        us_Correo = q.us_Correo,
                        us_Descripcion = q.us_Descripcion,
                        us_Estado = q.us_Estado,
                        us_DebeCambiarClave = q.us_DebeCambiarClave,
                        IdPerfil = q.IdPerfil
                    }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario_Info GetInfo(string IdUsuario, string Clave)
        {
            try
            {
                Usuario_Info info;
                IdUsuario = IdUsuario ?? string.Empty;
                Clave = Clave ?? string.Empty;

                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    info = db.Usuario.Where(q => q.IdUsuario.ToLower() == IdUsuario.Trim().ToLower() && q.us_Clave.ToLower() == Clave.Trim().ToLower()).Select(q => new Usuario_Info
                    {
                        IdUsuario = q.IdUsuario,
                        IdPerfil = q.IdPerfil,
                        us_Clave = q.us_Clave,
                        us_Correo = q.us_Correo,
                        us_DebeCambiarClave = q.us_DebeCambiarClave,
                        us_Descripcion = q.us_Descripcion,
                        us_Estado = q.us_Estado
                    }).FirstOrDefault();
                }

                return info;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario_Info GetInfo(string IdUsuario)
        {
            try
            {
                Usuario_Info info;
                IdUsuario = IdUsuario ?? string.Empty;

                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    info = db.Usuario.Where(q => q.IdUsuario.ToLower() == IdUsuario.Trim().ToLower()).Select(q => new Usuario_Info
                    {
                        IdUsuario = q.IdUsuario,
                        IdPerfil = q.IdPerfil,
                        us_Clave = q.us_Clave,
                        us_Correo = q.us_Correo,
                        us_DebeCambiarClave = q.us_DebeCambiarClave,
                        us_Descripcion = q.us_Descripcion,
                        us_Estado = q.us_Estado
                    }).FirstOrDefault();
                }

                return info;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Guardar(Usuario_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    db.Usuario.Add(new Usuario
                    {
                        IdUsuario = info.IdUsuario,
                        IdPerfil = "1",
                        us_Clave = info.us_Clave,
                        us_Correo = info.us_Correo,
                        us_DebeCambiarClave = info.us_DebeCambiarClave,
                        us_Descripcion = info.us_Descripcion,
                        us_Estado = true
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

        public bool Modificar(Usuario_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    var Entity = db.Usuario.Where(q => q.IdUsuario == info.IdUsuario).FirstOrDefault();
                    if (Entity != null)
                    {
                        Entity.us_Clave = info.us_Clave;
                        Entity.us_Descripcion = info.us_Descripcion;
                        Entity.us_Correo = info.us_Correo;
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Anular(Usuario_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    var Entity = db.Usuario.Where(q => q.IdUsuario == info.IdUsuario).FirstOrDefault();
                    if (Entity != null)
                    {
                        Entity.us_Estado = false;
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ValidarUsuarioExiste(string IdUsuario)
        {
            try
            {
                IdUsuario = IdUsuario ?? string.Empty;

                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    if (db.Usuario.Where(q => q.IdUsuario == IdUsuario).Count() > 0)
                        return true;
                    else
                        return false;
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
