using ASPMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPMVC.Controllers
{
    public class PauseController : Controller
    {
        public IActionResult Index(int tempsdemande)
        {
            
            ViewBag.Message = Outils.CestQuandLaPause(tempsdemande);
            return View();
        }
    }
}
