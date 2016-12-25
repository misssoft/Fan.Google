using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Drive.v3;
using Google.Apis.Util.Store;
using System;
using System.Web.Mvc;

namespace SearchConsole.GoogleApi
{
    public class AppFlowMetadata : FlowMetadata
    {
        public static readonly IAuthorizationCodeFlow _flow =
            new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = "859958412250-cvvc36beqk90eqru4hipu6351fjrprmn.apps.googleusercontent.com",
                    ClientSecret = "HWk3g0p3fkg1nXCOjaiHU_ew"
                },
                Scopes = new[] { DriveService.Scope.Drive },
                DataStore = new FileDataStore("Drive.Api.Auth.Store")
            });

        public override IAuthorizationCodeFlow Flow
        {
            get { return _flow; }
        }

        public override string GetUserId(Controller controller)
        {
            var user = controller.Session["user"];
            if (user == null)
            {
                user = Guid.NewGuid();
                controller.Session["user"] = user;
            }
            return user.ToString();
        }


    }
}