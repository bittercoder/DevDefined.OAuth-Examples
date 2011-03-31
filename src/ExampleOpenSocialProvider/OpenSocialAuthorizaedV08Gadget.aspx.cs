using System;
using System.Web.UI;

namespace ExampleOpenSocialProvider
{
	public partial class OpenSocialAuthorizaedV08Gadget : Page
	{
		protected string SocialServiceUrl
		{
			get { return UrlUtility.ToAbsolute("~/SocialService.aspx"); }
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			Response.ContentType = "application/xml";
		}
	}
}