using DevDefined.OAuth.Provider;
using DevDefined.OAuth.Storage.Basic;

namespace ExampleOpenSocialProvider
{
  public interface IOAuthServices
  {
    IOAuthProvider Provider { get; }
    ITokenRepository<AccessToken> AccessTokenRepository { get; }
    ITokenRepository<RequestToken> RequestTokenRepository { get; }
  }
}