using Stratsys.Apis.v1.Apis.Kpis.Requests;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Kpis.Resources
{
    public class KpiColumnResource
    {
        private readonly IClientService m_clientService;

        public KpiColumnResource(IClientService clientService)
        {
            m_clientService = clientService;
        }

        public FilterKpiColumnsRequest Filter(
            string kpiId, 
            string departmentId = null,
            string name = null
            )
        {
            return new FilterKpiColumnsRequest(m_clientService, kpiId, departmentId, name);
        }
    }
}