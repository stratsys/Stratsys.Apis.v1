using Stratsys.Apis.v1.Apis.Organization.Resources;

namespace Stratsys.Apis.v1.Apis.Organization.Services
{
    public class UserService : StratsysClientService
    {
        public UserService(StratsysAuthentication authentication)
            : base(authentication)
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