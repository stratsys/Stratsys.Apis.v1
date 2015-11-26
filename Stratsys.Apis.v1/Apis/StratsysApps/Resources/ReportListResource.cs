using Stratsys.Apis.v1.Apis.StratsysApps.Requests;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.StratsysApps.Resources
{
    public class ReportListResource
    {
        private readonly IClientService m_clientService;

        public ReportListResource(IClientService clientService)
        {
            m_clientService = clientService;
        }

        public GetUserReportListItemsRequest GetItemsForUser(string reportListId, string userId, bool? showAll = null)
        {
            return new GetUserReportListItemsRequest(m_clientService, reportListId, userId, showAll);
        }
    }
}