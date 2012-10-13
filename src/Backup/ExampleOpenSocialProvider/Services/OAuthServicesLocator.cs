using System.Web;

namespace ExampleOpenSocialProvider
{
  public static class OAuthServicesLocator
  {
    public static IOAuthServices Services
    {
      get { return (HttpContext.Current.ApplicationInstance as IOAuthServices); }
    }
  }
}