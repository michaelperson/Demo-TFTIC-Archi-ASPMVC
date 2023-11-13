using ASPMVC.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ASPMVC.Controllers
{
    public class MathController : Controller
    {
        private readonly ILogger<MathController> _logger;
        private MathUtils _monMath;

        public MathController(ILogger<MathController> logger)
        {
            _logger = logger;
            _monMath = new MathUtils();
        }

        public IActionResult Index()
        {
            _logger.LogInformation($"{HttpContext.Request.GetDisplayUrl().Replace("/Index","")}/Table/#\t\tAffiche la table de multiplication de #\n{HttpContext.Request.GetDisplayUrl().Replace("/Index","")}/#/Table");
            _logger.LogInformation($"{HttpContext.Request.GetDisplayUrl().Replace("/Index", "")}/EstPaire/#\t\tAffiche un booléen selon si le nombre est paire");
            _logger.LogInformation($"{HttpContext.Request.GetDisplayUrl().Replace("/Index", "")}/Multiplication?nb1=#&nb2=#\t\tAffiche le résultat de la multiplication de nb1 par nb2");
            string menu = 
@$"{HttpContext.Request.GetDisplayUrl().Replace("/Index","")}/Table/#       Affiche la table de multiplication de #
{HttpContext.Request.GetDisplayUrl().Replace("/Index","")}/#/Table
{HttpContext.Request.GetDisplayUrl().Replace("/Index", "")}/EstPaire/#      Affiche un booléen selon si le nombre est paire
{HttpContext.Request.GetDisplayUrl().Replace("/Index", "")}/Multiplication?nb1=#&nb2=#      Affiche le résultat de la multiplication de nb1 par nb2";
            return Ok(menu);
        }
    
        public IActionResult EstPaire(int id) {
            _logger.LogInformation($"{id} est paire: {id % 2 == 0}");
            return Ok(_monMath.EstPair(id));
        }

        public IActionResult Multiplication(int nb1, int nb2) {
            _logger.LogInformation($"{nb1} * {nb2} = {nb1*nb2}");
            return Ok(nb1 * nb2);
        }

        [Route("Math/Table/{id}")]
        [Route("Math/{id}/Table")]
        public IActionResult Table(int id)
        {
            string message = "";
            for (int i = 1; i <= 10; i++)
            {
                string calcul = $"{id} * {i} = {id * i}";
                _logger.LogInformation(calcul);
                message += calcul + "\n";
            }

            return Ok(message);
        }
    }
}
