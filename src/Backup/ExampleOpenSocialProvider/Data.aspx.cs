#region License

// The MIT License
//
// Copyright (c) 2006-2008 DevDefined Limited.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Xml.Linq;
using DevDefined.OAuth.Framework;
using DevDefined.OAuth.Provider;
using ExampleOpenSocialProvider.Repositories;
using Newtonsoft.Json;

namespace ExampleOpenSocialProvider
{
	public class ContactsDto
	{
		public string Title { get; set; }
		public IList<Contact> Contacts { get; set; }
	}

  public partial class Data : Page
  {
		ContactsRepository repository = new ContactsRepository();

    protected void Page_Load(object sender, EventArgs e)
    {
      var context = new OAuthContextBuilder().FromHttpRequest(Request);

      IOAuthProvider provider = OAuthServicesLocator.Services.Provider;

      var tokenRepository = OAuthServicesLocator.Services.AccessTokenRepository;

      try
      {
				
				provider.AccessProtectedResourceRequest(context);

        var accessToken = tokenRepository.GetToken(context.Token);

				string userName = accessToken.UserName;

      	var contactsDto = new {
      	                  	Contacts = repository.GetContactsForUser(userName),
														Title = string.Format("Contacts for user \"" + userName + "\"")
      	                  };

				Response.ContentType = "application/json";
				Response.Write(JsonConvert.SerializeObject(contactsDto));
        Response.End();
      }
      catch (OAuthException authEx)
      {
        // fairly naieve approach to status codes, generally you would want to examine eiter the inner exception of the 
        // problem report to determine an appropriate status code for your technology / architecture.

        Response.StatusCode = 403;
        Response.Write(authEx.Report);
        Response.End();
      }
    }
  }
}