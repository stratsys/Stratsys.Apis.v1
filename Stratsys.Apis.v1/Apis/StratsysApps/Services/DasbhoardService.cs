using Stratsys.Apis.v1.Apis.StratsysApps.Resources;

namespace Stratsys.Apis.v1.Apis.StratsysApps.Services
{
    public class DasbhoardService : StratsysClientService
    {
        public DasbhoardService(StratsysAuthentication authentication)
            : base(authentication)
        {
            Dashboards = new DashboardResource(this);
        }

        public override string Controller
        {
            get { return "stratsys-apps/dashboards"; }
        }

        public DashboardResource Dashboards { get; private set; }
    }
}