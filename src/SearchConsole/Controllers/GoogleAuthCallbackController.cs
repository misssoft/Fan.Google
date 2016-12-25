using SearchConsole.GoogleApi;
using System.Web.Mvc;

namespace SearchConsole.Controllers
{
    public class GoogleAuthCallbackController : Controller
    {
        // GET: GoogleAuthCallback
        public class AuthCallbackController : Google.Apis.Auth.OAuth2.Mvc.Controllers.AuthCallbackController
        {
            protected override Google.Apis.Auth.OAuth2.Mvc.FlowMetadata FlowData
            {
                get { return new AppFlowMetadata(); }
            }
        }
    }
}