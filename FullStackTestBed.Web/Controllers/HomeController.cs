using System.Web.Mvc;

namespace FullStackTestBed.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}