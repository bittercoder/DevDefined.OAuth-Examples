using System;
using System.Diagnostics;
using System.IO;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;

namespace ExampleDropBoxUpload
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var consumerContext = new OAuthConsumerContext
                {
                    SignatureMethod = SignatureMethod.HmacSha1,
                    ConsumerKey = "dai4siwkt27bo3r", // this is just a sample app setup for demo purposes called "DevDefinedOAuthTest", it's a sandbox app in "Development" mode.
                    ConsumerSecret = "emsponeqnebimbm", 
                    UseHeaderForOAuthParameters = true // this is required for the PUT request with raw body to succeed.
                };

            var session = new OAuthSession(consumerContext, "https://api.dropbox.com/1/oauth/request_token",
                                           "https://www.dropbox.com/1/oauth/authorize",
                                           "https://api.dropbox.com/1/oauth/access_token");

            IToken requestToken = session.GetRequestToken();

            string authorisationUrl = session.GetUserAuthorizationUrlForToken(requestToken);

            Console.WriteLine("Authorization Url: {0}", authorisationUrl);

            Process.Start(authorisationUrl);

            Console.WriteLine();

            Console.WriteLine("Press enter once authorization complete");

            Console.ReadLine();

            session.ExchangeRequestTokenForAccessToken(requestToken);

            string accountInfo = session.Request().Get().ForUrl("https://api.dropbox.com/1/account/info").ReadBody();

            Console.WriteLine("Account info: {0}", accountInfo);

            Console.WriteLine();

            Console.WriteLine("Press enter to continue (will put file into sandbox)");

            const string root = "sandbox"; // can also be "dropbox" (if app has all folders access)

            string fileName = "img_" + Guid.NewGuid() + ".png";

            string putUrl = string.Format("https://api-content.dropbox.com/1/files_put/{0}/{1}", root, fileName);

            byte[] contents = File.ReadAllBytes("DevDefinedOAuthTitle.png");

            IConsumerRequest putRequest = session.Request().Put().ForUrl(putUrl).WithRawContent(contents);

            string putInfo = putRequest.ReadBody();

            Console.WriteLine("Put response: {0}", putInfo);

            Console.WriteLine();

            Console.WriteLine("Press enter to exit");

            Console.ReadLine();
        }
    }
}