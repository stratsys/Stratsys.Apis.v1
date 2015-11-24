using Stratsys.Apis.v1.Apis.Applications.Resources;

namespace Stratsys.Apis.v1.Apis.Applications.Services
{
    public class ApplicationService : StratsysClientService
    {
        public ApplicationService(StratsysAuthentication authentication) : base(authentication)
        {
            Applications = new ApplicationResource(this);
        }

        public override string Controller
        {
            get { return "applications"; }
        }

        public ApplicationResource Applications { get; private set; }
    }
}