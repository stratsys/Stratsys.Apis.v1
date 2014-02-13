namespace Stratsys.Apis.v1.Apis.Kpis
{
    public class KpiDataService : StratsysClientService
    {
        public KpiDataService(string clientId, string clientSecret)
            : base(clientId, clientSecret)
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