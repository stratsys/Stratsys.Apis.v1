using Stratsys.Apis.v1.Apis.StratsysApps.Requests;
using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.StratsysApps.Resources
{
    public class DashboardResource
    {
        private readonly IClientService m_clientService;

        public DashboardResource(IClientService clientService)
        {
            m_clientService = clientService;
        }

        public FilterDashboardsRequest List(string userId, bool? onlyStartpage = null)
        {
            return new FilterDashboardsRequest(m_clientService, userId, onlyStartpage);
        }
    }
}