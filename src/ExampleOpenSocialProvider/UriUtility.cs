using System;
using System.Web;

namespace ExampleOpenSocialProvider
{
	public static class UrlUtility
	{
		public static string ToAbsolute(string relative)
		{
			Uri url = HttpContext.Current.Request.Url;
			return url.Scheme + "://" + url.Authority + VirtualPathUtility.ToAbsolute(relative);
		}
	}
}