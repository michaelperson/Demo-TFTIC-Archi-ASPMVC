using ASPMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPMVC.Controllers
{
    public class CalculetteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Addition() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Addition(AdditionClass monAddition, string Chiffre1)
        {
            if (ModelState.IsValid)
            {

                return Ok(monAddition.Chiffre1 + monAddition.Chiffre2);
            }
            else
            {
                return NotFound("GROSSE ERREUR");
            }
        }
    }
}
