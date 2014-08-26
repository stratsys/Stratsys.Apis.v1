using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Resources
{
    public class ScorecardNodeResource
    {
        private readonly IClientService m_clientService;

        public ScorecardNodeResource(IClientService clientService)
        {
            m_clientService = clientService;
        }

        public GetRequest<ScorecardNodeDto> Get(string id)
        {
            return new GetRequest<ScorecardNodeDto>(m_clientService, id);
        }

        public FilterRequest<ScorecardNodeDto> Filter(string name)
        {
            var filterRequest = new FilterRequest<ScorecardNodeDto>(m_clientService);
            filterRequest.RequestParameters.Add("name",name);
            return filterRequest;
        }
    }
}