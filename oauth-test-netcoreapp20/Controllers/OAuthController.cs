using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Smartsheet.Api.OAuth;

namespace oauth_test_netcoreapp20.Controllers
{
    [Route("oauth")]
    public class OAuthController : ControllerBase
    {
        private string ClientId = "[CHANGE ME]";
        private string ClientSecret = "[CHANGE ME]";

        // GET oauth
        [HttpGet]
        public RedirectResult SignIn()
        {
            OAuthFlow oauth = new OAuthFlowBuilder()
                .SetTokenURL("https://api.smartsheet.com/2.0/token")
                .SetAuthorizationURL("https://www.smartsheet.com/b/authorize")
                .SetClientId(ClientId)
                .SetClientSecret(ClientSecret)
                .SetRedirectURL("http://localhost:55989/oauth/signin")
                .Build();

            String url = oauth.NewAuthorizationURL(new List<AccessScope> { AccessScope.READ_SHEETS }, "/");
            return RedirectPermanent(url);
        }

        // GET oauth/signin
        [HttpGet("signin")]
        public string SignInCallback(string code, int expires_in, string state)
        {
            OAuthFlow oauth = new OAuthFlowBuilder()
                .SetTokenURL("https://api.smartsheet.com/2.0/token")
                .SetAuthorizationURL("https://www.smartsheet.com/b/authorize")
                .SetClientId(ClientId)
                .SetClientSecret(ClientSecret)
                .SetRedirectURL("http://localhost:55989/oauth/signin")
                .Build();

            AuthorizationResult authResult = oauth.ExtractAuthorizationResult("http://localhost:55989/oauth/signin" + Request.QueryString.ToString());
            Token token = oauth.ObtainNewToken(authResult);

            return token.AccessToken;
        }
    }
}
