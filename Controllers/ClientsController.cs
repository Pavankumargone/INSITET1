using Microsoft.AspNetCore.Mvc;

namespace REPORTS.Controllers
{
    public class ClientsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
