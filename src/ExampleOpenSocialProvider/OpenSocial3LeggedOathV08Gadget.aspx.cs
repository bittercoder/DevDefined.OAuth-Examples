using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExampleOpenSocialProvider
{
	public partial class OpenSocial3LeggedOathV08Gadget : System.Web.UI.Page
	{
		protected string ContactsAccessUrl
		{
			get { return UrlUtility.ToAbsolute("~/GetAccessToken.aspx"); }
		}

		protected string ContactsRequestUrl
		{
			get { return UrlUtility.ToAbsolute("~/GetRequestToken.aspx"); }
		}

		protected string ContactAuthorizationUrl
		{
			get { return UrlUtility.ToAbsolute("~/UserAuthorize.aspx"); }
		}

		protected string DataUrl
		{
			get { return UrlUtility.ToAbsolute("~/Data.aspx"); }
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			Response.ContentType = "application/xml";
		}
	}
}