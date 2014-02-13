using Stratsys.Apis.v1.Apis.Kpis.Requests;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Kpis
{
    public class KpiResource
    {
        private readonly IClientService m_clientService;

        public KpiResource(IClientService clientService)
        {
            m_clientService = clientService;
        }

        public FilterKpisRequest Filter(
            string id = null, 
            string departmentId = null, 
            string name = null, 
            string scorecardId = null)
        {
            return new FilterKpisRequest(m_clientService, id, departmentId, name, scorecardId);
        }
    }
}