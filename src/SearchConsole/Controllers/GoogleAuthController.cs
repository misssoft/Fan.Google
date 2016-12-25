using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using SearchConsole.GoogleApi;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SearchConsole.Controllers
{
    public class GoogleAuthController : Controller
    {
        public async Task IndexAsync(CancellationToken cancellationToken)
        {
            var result = await new AuthorizationCodeMvcApp(this, new AppFlowMetadata()).
                AuthorizeAsync(cancellationToken);

            if (result.Credential != null)
            {
                var service = new DriveService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = result.Credential,
                    ApplicationName = "ASP.NET MVC Sample"
                });

                // YOUR CODE SHOULD BE HERE..
                // SAMPLE CODE:
                var list = await service.Files.List().ExecuteAsync(cancellationToken);
                ViewBag.Message = "FILE COUNT IS: " + list.Files.Count;
                View();
            }
            else
            {
                new RedirectResult(result.RedirectUri);
            }
        }
    }
}