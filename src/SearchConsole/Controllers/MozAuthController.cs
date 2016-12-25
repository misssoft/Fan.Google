using SearchConsole.MozApi;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SearchConsole.Controllers
{
    public class MozAuthController : Controller
    {
        // GET: MozAuth
        public async Task<ActionResult> Index()
        {
            var mozAuthService = new MozAuthService();
            var result = await mozAuthService.MozAuth(null, null);

            ViewBag.StatusCode = result.StatusCode;
            ViewBag.Message = result.ReasonPhrase;
            ViewBag.RequestMessage = result.RequestMessage;
            return View();
        }
    }
}