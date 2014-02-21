using Stratsys.Apis.v1.Apis.Organization.Resources;

namespace Stratsys.Apis.v1.Apis.Organization.Services
{
    public class UserService : StratsysClientService
    {
        public UserService(string clientId, string clientSecret)
            : base(clientId, clientSecret)
        {
            Users = new UserResource(this);
        }

        public override string Controller
        {
            get { return "users"; }
        }

        public UserResource Users { get; private set; }
    }
}