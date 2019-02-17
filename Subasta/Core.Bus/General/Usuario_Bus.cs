using Core.Data.General;
using Core.Info.General;
using System;

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
    }
}
