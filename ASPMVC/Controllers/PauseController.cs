using ASPMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPMVC.Controllers
{
 
    public class PauseController : Controller
    {
        public IActionResult Index(int tempsdemande)
        {
            
            ViewBag.Message = Outils.CestQuandLaPause(tempsdemande,"11:00");
            return View();
        }

        [HttpGet] //INIT
        public IActionResult GetPause()
        {
            return View();
        }

        [HttpPost] //Post-traitement
        public IActionResult GetPause(string Choix, string Role)
        {
            int tempsAjouter = Role == "Formateur" ? 20 : 0;
            string message = "";
            if (Choix == "Matin") { message = Outils.CestQuandLaPause(15+tempsAjouter, "10:15"); }
            if (Choix == "Midi") { message = Outils.CestQuandLaPause(60+tempsAjouter, "12:00"); }
            if (Choix == "Aprem") { message = Outils.CestQuandLaPause(15+tempsAjouter, "16:40"); }
           
            //on dépose la valeur dans un sac de 
            // transport à usage unique pour la vue
            ViewBag.Message = message;

            return View();
        }

        #region Ma proposition
        //[HttpGet]
        //public IActionResult CalculTemps()
        //{
        //    return View("CalculTempsFormateur");
        //}
        //[HttpPost]
        //public IActionResult CalculTemps(EPauses Pause, string Role)
        //{
        //    int ajout = Role == "Formateur" ? 20 : 0;
        //    switch (Pause)
        //    {
        //        case EPauses.matin: ViewBag.Message= Outils.CestQuandLaPause(15+ ajout, "10:15"); break;
        //        case EPauses.midi: ViewBag.Message=Outils.CestQuandLaPause(60+ ajout, "12:15"); break;
        //        case EPauses.aprem: ViewBag.Message= Outils.CestQuandLaPause(15+ ajout, "15:15"); break;


        //    }

        //    return View("CalculTempsFormateur");
        //} 
        #endregion
    }
}
