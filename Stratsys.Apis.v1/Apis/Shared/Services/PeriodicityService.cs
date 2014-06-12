using Stratsys.Apis.v1.Apis.Shared.Resources;

namespace Stratsys.Apis.v1.Apis.Shared.Services
{
    public class PeriodicityService : StratsysClientService
    {
        public PeriodicityService(StratsysAuthentication authentication)
            : base(authentication)
        {
            Periodicities = new PeriodicityResource(this);
        }

        public override string Controller
        {
            get { return "periodicities"; }
        }

        public PeriodicityResource Periodicities { get; private set; }
    }
}