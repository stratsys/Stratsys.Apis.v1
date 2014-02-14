using Stratsys.Apis.v1.Apis.Scorecards.Requests;
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

        public GetScorecardRequest Get(string scorecard)
        {
            return new GetScorecardRequest(m_service, scorecard);
        }
    }
}