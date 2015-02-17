using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Resources
{
    public class ScorecardViewResource
    {
        private readonly IClientService m_clientService;

        public ScorecardViewResource(IClientService clientService)
        {
            m_clientService = clientService;
        }

        public FilterRequest<ScorecardViewDto> Filter(string scorecardColumnId)
        {
            var filterRequest = new FilterRequest<ScorecardViewDto>(m_clientService);
            filterRequest.RequestParameters.Add("scorecardColumnId", scorecardColumnId);
            return filterRequest;
        }

        public GetRequest<string> GetUrl(string scorecardViewId, string departmentId = null, string nodeId = null)
        {
            var request = new GetRequest<string>(m_clientService, scorecardViewId + "/url");
            request.RequestParameters.Add("departmentId", departmentId);
            request.RequestParameters.Add("nodeId", nodeId);
            return request;
        }
    }
}