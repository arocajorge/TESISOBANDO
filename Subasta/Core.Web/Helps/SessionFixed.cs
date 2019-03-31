using System.Web;

namespace Core.Erp.Web.Helps
{
    public interface ISessionValueProvider
    {
        string IdUsuario { get; set; }
        string NombreUsuario { get; set; }
        string IdTransaccionSession { get; set; }
        string IdTransaccionSessionActual { get; set; }

        string IdCategoria { get; set; }
        string IdLinea { get; set; }
        string IdSubasta { get; set; }
        string IdProveedor { get; set; }
    }

    public static class SessionFixed
    {
        private static ISessionValueProvider _sessionValueProvider;
        public static void SetSessionValueProvider(ISessionValueProvider provider)
        {
            _sessionValueProvider = provider;
        }
        public static string IdUsuario
        {
            get { return _sessionValueProvider.IdUsuario; }
            set { _sessionValueProvider.IdUsuario = value; }
        }
        public static string NombreUsuario
        {
            get { return _sessionValueProvider.NombreUsuario; }
            set { _sessionValueProvider.NombreUsuario = value; }
        }
        public static string IdTransaccionSession
        {
            get { return _sessionValueProvider.IdTransaccionSession; }
            set { _sessionValueProvider.IdTransaccionSession = value; }
        }
        public static string IdTransaccionSessionActual
        {
            get { return _sessionValueProvider.IdTransaccionSessionActual; }
            set { _sessionValueProvider.IdTransaccionSessionActual = value; }
        }

        public static string IdCategoria
        {
            get { return _sessionValueProvider.IdCategoria; }
            set { _sessionValueProvider.IdCategoria = value; }
        }
        public static string IdLinea
        {
            get { return _sessionValueProvider.IdLinea; }
            set { _sessionValueProvider.IdLinea = value; }
        }
        public static string IdSubasta
        {
            get { return _sessionValueProvider.IdSubasta; }
            set { _sessionValueProvider.IdSubasta = value; }
        }
        public static string IdProveedor
        {
            get { return _sessionValueProvider.IdProveedor; }
            set { _sessionValueProvider.IdProveedor = value; }
        }
    }

    public class WebSessionValueProvider : ISessionValueProvider
    {
        private const string _IdUsuario = "Su_IdUsuario";
        private const string _NombreUsuario = "Su_NombreUsuario";
        private const string _IdTransaccionSession = "Su_IdTransaccionSesssion";
        private const string _IdTransaccionSessionActual = "Su_IdTransaccionSessionActual";
        private const string _IdCategoria= "Su_IdCategoria";
        private const string _IdLinea = "Su_IdLinea";
        private const string _IdSubasta = "Su_IdSubasta";
        private const string _IdProveedor = "Su_IdProveedor";

        public string IdUsuario
        {
            get { return (string)HttpContext.Current.Session[_IdUsuario]; }
            set { HttpContext.Current.Session[_IdUsuario] = value; }
        }
        public string NombreUsuario
        {
            get { return (string)HttpContext.Current.Session[_NombreUsuario]; }
            set { HttpContext.Current.Session[_NombreUsuario] = value; }
        }
        public string IdTransaccionSession
        {
            get { return (string)HttpContext.Current.Session[_IdTransaccionSession]; }
            set { HttpContext.Current.Session[_IdTransaccionSession] = value; }
        }
        public string IdTransaccionSessionActual
        {
            get { return (string)HttpContext.Current.Session[_IdTransaccionSessionActual]; }
            set { HttpContext.Current.Session[_IdTransaccionSessionActual] = value; }
        }
        public string IdCategoria
        {
            get { return (string)HttpContext.Current.Session[_IdCategoria]; }
            set { HttpContext.Current.Session[_IdCategoria] = value; }
        }
        public string IdLinea
        {
            get { return (string)HttpContext.Current.Session[_IdLinea]; }
            set { HttpContext.Current.Session[_IdLinea] = value; }
        }
        public string IdSubasta
        {
            get { return (string)HttpContext.Current.Session[_IdSubasta]; }
            set { HttpContext.Current.Session[_IdSubasta] = value; }
        }
        public string IdProveedor
        {
            get { return (string)HttpContext.Current.Session[_IdProveedor]; }
            set { HttpContext.Current.Session[_IdProveedor] = value; }
        }
    }
}