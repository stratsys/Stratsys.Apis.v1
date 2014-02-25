using Stratsys.Apis.v1.Apis.Gadgets.Requests;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Gadgets.Resources
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

        public GetUserReportingListRequest GetItemsForUser(string reportingListId, string userId, bool? showAll = null)
        {
            return new GetUserReportingListRequest(m_clientService, reportingListId, userId, showAll);
        }
    }
}