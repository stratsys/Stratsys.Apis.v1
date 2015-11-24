using Stratsys.Apis.v1.Apis.Scorecards.Resources;

namespace Stratsys.Apis.v1.Apis.Scorecards.Services
{
    public class VersionService : StratsysClientService
    {
        public VersionService(StratsysAuthentication authentication) : base(authentication)
        {
            Versions=new VersionResource(this);
        }

        public override string Controller
        {
            get { return "versions"; }
        }

        public VersionResource Versions { get; set; }
    }
}