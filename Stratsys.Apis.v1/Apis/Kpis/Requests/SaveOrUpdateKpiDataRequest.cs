using Stratsys.Apis.v1.Dtos.Kpis;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Kpis.Requests
{
    public class SaveOrUpdateKpiDataRequest : StratsysClientRequest<double?>
    {
        private readonly KpiDataDto m_kpiData;

        public SaveOrUpdateKpiDataRequest(
            IClientService clientService,
            KpiDataDto kpiData
            )
            : base(clientService)
        {
            m_kpiData = kpiData;
        }

        public override string HttpMethod
        {
            get { return "PUT"; }
        }

        public override object Body
        {
            get { return m_kpiData; }
        }
    }
}