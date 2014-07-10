using Stratsys.Apis.v1.Apis.Scorecards.Requests;
using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Resources
{
    public class ScorecardColumnResource
    {
        private readonly IClientService m_service;

        public ScorecardColumnResource(IClientService service)
        {
            m_service = service;
        }

        public GetScorecardColumnRequest Get(string id)
        {
            return new GetScorecardColumnRequest(m_service, id);
        }

        public FilterScorecardColumnsRequest Filter(
            string scorecardId = null,
            string name = null,
            int? index = null,
            NodeTypeDto? nodeType = null)
        {
            return new FilterScorecardColumnsRequest(m_service, scorecardId, name, index, nodeType);
        }
    }
}