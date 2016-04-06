using Stratsys.Apis.v1.Apis.Organization.Resources;

namespace Stratsys.Apis.v1.Apis.Organization.Services
{
    public class ExternalPageService : StratsysClientService
    {
        public ExternalPageService(StratsysAuthentication authentication)
            : base(authentication)
        {
            ExternalPages = new ExternalPageResource(this);
        }

        public override string Controller
        {
            get { return "externalpages"; }
        }

        public ExternalPageResource ExternalPages { get; private set; }
    }
}