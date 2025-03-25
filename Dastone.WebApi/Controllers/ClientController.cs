using Microsoft.AspNetCore.Mvc;

namespace Dastone.WebApi.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
