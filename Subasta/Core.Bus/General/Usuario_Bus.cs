using Core.Data.General;
using Core.Info.General;
using System;
using System.Collections.Generic;

namespace Core.Bus.General
{
    public class Usuario_Bus
    {
        Usuario_Data odata = new Usuario_Data();
        public Usuario_Info GetInfo(string IdUsuario, string Clave)
        {
            try
            {
                return odata.GetInfo(IdUsuario, Clave);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Usuario_Info> GetList()
        {
            try
            {
                return odata.GetList();
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
                return odata.GetInfo(IdUsuario);
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
                return odata.Guardar(info);
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
                return odata.Modificar(info);
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
                return odata.Anular(info);
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
                return odata.ValidarUsuarioExiste(IdUsuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
