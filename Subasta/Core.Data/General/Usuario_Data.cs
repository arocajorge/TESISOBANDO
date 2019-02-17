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
    }
}
