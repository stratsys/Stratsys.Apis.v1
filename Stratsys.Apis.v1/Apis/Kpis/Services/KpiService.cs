using Stratsys.Apis.v1.Apis.Kpis.Resources;

namespace Stratsys.Apis.v1.Apis.Kpis.Services
{
    public class KpiService : StratsysClientService
    {
        public KpiService(StratsysAuthentication authentication)
            : base(authentication)
        {
            Kpis = new KpiResource(this);
        }

        public override string Controller
        {
            get { return "kpis"; }
        }

        public KpiResource Kpis { get; private set; }
    }
}