using Stratsys.Apis.v1.Apis.Kpis.Resources;

namespace Stratsys.Apis.v1.Apis.Kpis.Services
{
    public class KpiDataService : StratsysClientService
    {
        public KpiDataService(StratsysAuthentication authentication)
            : base(authentication)
        {
            KpiData = new KpiDataResource(this);
        }

        public override string Controller
        {
            get { return "kpidata"; }
        }

        public KpiDataResource KpiData { get; private set; }
    }
}