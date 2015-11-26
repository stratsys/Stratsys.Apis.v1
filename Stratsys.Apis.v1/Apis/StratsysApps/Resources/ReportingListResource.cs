using Stratsys.Apis.v1.Apis.StratsysApps.Requests;
using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.StratsysApps.Resources
{
    public class ReportingListResource
    {
        private readonly IClientService m_clientService;

        public ReportingListResource(IClientService clientService)
        {
            m_clientService = clientService;
        }

        public ListReportingListsRequest List()
        {
            return new ListReportingListsRequest(m_clientService);
        }

        public FilterReportingListsRequest Filter(
            string name = null,
            NodeTypeDto? nodeTypeDto = null,
            string dashboardId = null
            )
        {
            return new FilterReportingListsRequest(m_clientService, name, nodeTypeDto, dashboardId);
        }

        public GetUserReportingListRequest GetItemsForUser(string reportingListId, string userId, bool? showAll = null)
        {
            return new GetUserReportingListRequest(m_clientService, reportingListId, userId, showAll);
        }
    }
}