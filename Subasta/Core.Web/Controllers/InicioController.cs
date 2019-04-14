using Core.Web.Helps;
using System.Web.Mvc;

namespace Core.Web.Controllers
{
    [SessionTimeout]
    public class InicioController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}