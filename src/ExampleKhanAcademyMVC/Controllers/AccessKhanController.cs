using System;
using System.Collections.Specialized;
using System.Web.Mvc;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;

namespace ExampleKhanAcademyMVC.Controllers
{
    public class AccessKhanController : Controller
    {
        const string ConsumerKey = "GykYsfASK3eEAH7G";
        const string ConsumerSecret = "5VVwpj9G5NzM659E";
        static IToken lastAccessToken;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Start()
        {
            OAuthSession session = BuildSession();

            RequestDescription requestTokenRequest = session
                .BuildRequestTokenContext("GET")
                .GetRequestDescription();

            return new RedirectResult(requestTokenRequest.Url.OriginalString);
        }

        string GetCallbackUrl()
        {
            string url = Request.Url.ToString();

            url = url.Substring(0, url.LastIndexOf("/")) + "/Callback";

            return url;
        }

        OAuthSession BuildSession()
        {
            var consumerContext = new OAuthConsumerContext
                {
                    SignatureMethod = SignatureMethod.HmacSha1,
                    ConsumerKey = ConsumerKey,
                    ConsumerSecret = ConsumerSecret,
                    UseHeaderForOAuthParameters = false
                };

            var session = new OAuthSession(consumerContext,
                requestTokenUrl: "http://www.khanacademy.org/api/auth/request_token",
                userAuthorizeUrl: "http://www.khanacademy.org/api/auth/request_token", /* not used by the khanacademy flow - they combine the first and second leg together */
                accessTokenUrl: "http://www.khanacademy.org/api/auth/access_token")
                {
                    CallbackUri = new Uri(GetCallbackUrl())
                };

            session.AccessToken = lastAccessToken;            

            return session;
        }

        public ActionResult Callback(string oauth_token, string oauth_token_secret, string oauth_verifier)
        {
            OAuthSession session = BuildSession();

            var requestToken = new TokenBase {TokenSecret = oauth_token_secret, Token = oauth_token};

            IToken accessToken = session.ExchangeRequestTokenForAccessToken(requestToken, "GET", oauth_verifier);

            lastAccessToken = accessToken;

            return View(accessToken);
        }

        public ActionResult Exercises()
        {
            OAuthSession session = BuildSession();
            
            string response = session.Request().ForMethod("GET").ForUrl("http://www.khanacademy.org/api/v1/user/exercises").SignWithToken().ReadBody();

            return View((object) response);
        }

        static string ParseResponseParameter(NameValueCollection collection, string parameter)
        {
            string value = (collection[parameter] ?? "").Trim();
            return (value.Length > 0) ? value : null;
        }
    }
}