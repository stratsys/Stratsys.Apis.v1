using Stratsys.Apis.v1.Apis.Generics;
using Stratsys.Apis.v1.Apis.Scorecards.Requests;
using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Resources
{
    public class ScorecardResource
    {
        private readonly IClientService m_service;

        public ScorecardResource(IClientService service)
        {
            m_service = service;
        }

        public ListScorecardsRequest List()
        {
            return new ListScorecardsRequest(m_service);
        }

        public FilterRequest<ScorecardDto> Filter(string name)
        {
            var filterRequest = new FilterRequest<ScorecardDto>(m_service);
            filterRequest.RequestParameters.Add("name", name);
            return filterRequest;
        }

        public GetScorecardRequest Get(string scorecardId)
        {
            return new GetScorecardRequest(m_service, scorecardId);
        }
    }
}