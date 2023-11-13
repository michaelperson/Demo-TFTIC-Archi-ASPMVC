using Microsoft.AspNetCore.Mvc;

namespace ASPMVC.Controllers
{
    public class DemoController : Controller
    {
        private readonly ILogger<DemoController> _logger;

        public DemoController(ILogger<DemoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return Ok("Bienvenu dans la démo!");
        }

        [Route("DemoRouting")]
        [Route("Demo/Routing")]
        [Route("Demo/RoutingAttribute")]
        public IActionResult RoutingAttribute()
        {
            return Ok("J'ai atteint /Demo/RoutingAttribute à l'aide d'un RouteAttribute");
        }

        //GET : /Demo/LogChat?message=texte
        public IActionResult LogChat(string message)
        {
            //if (message is null) message = "Pas de message";  /*Avec if*/
            //OU
            //message = message ?? "Pas de message";            /*Avec Coalesce*/
            //OU
            message ??= "Pas de message";                       /*Avec affectation coalesce*/
            _logger.LogInformation(message);
            return Ok("Message envoyé!");
        }

        public IActionResult CheckId(string id)
        {
            if (int.TryParse(id, out int result))
            {
                return Ok($"L'id est {result} de type {result.GetType()}");
            }
            return Ok($"L'id est \"{id}\" de type {id.GetType()}");
        }

        public IActionResult RepeatId(int id, int nb=10) {
            for (int i = 0; i < nb; i++)
            {
                _logger.LogInformation(id.ToString());
            }
            return Ok($"Id répété {nb} fois!");
        }

    }
}
