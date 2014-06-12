using Stratsys.Apis.v1.Apis.Kpis.Resources;

namespace Stratsys.Apis.v1.Apis.Kpis.Services
{
    public class KpiColumnService: StratsysClientService
    {
        public KpiColumnService(StratsysAuthentication authentication)
            : base(authentication)
        {
            KpiColumns = new KpiColumnResource(this);
        }

        public override string Controller
        {
            get { return "kpicolumns"; }
        }

        public KpiColumnResource KpiColumns { get; private set; }
    }
}