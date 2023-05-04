using Microsoft.AspNetCore.Mvc;

namespace Sol.Pierr.Grimaldo.DistributedServices.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
