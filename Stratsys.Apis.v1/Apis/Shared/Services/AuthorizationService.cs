using Stratsys.Apis.v1.Apis.Shared.Resources;

namespace Stratsys.Apis.v1.Apis.Shared.Services
{
    public class AuthorizationService : StratsysClientService
    {
        public AuthorizationService(string clientId, string clientSecret)
            : base(clientId, clientSecret)
        {
            Authorizations = new AuthorizationResource(this);
        }

        public override string Controller
        {
            get { return "authorizations"; }
        }

        public AuthorizationResource Authorizations { get; private set; }
    }
}