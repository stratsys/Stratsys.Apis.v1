using Stratsys.Apis.v1.Apis.Generics;
using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Resources
{
    public class KeywordGroupResource
    {
        private readonly IClientService m_clientService;

        public KeywordGroupResource(IClientService clientService)
        {
            m_clientService = clientService;
        }

        public FilterRequest<KeywordGroupDto> Filter(string scorecardColumnId)
        {
            var filterRequest = new FilterRequest<KeywordGroupDto>(m_clientService);
            filterRequest.RequestParameters.Add("scorecardColumnId",scorecardColumnId);
            return filterRequest;
        }
    }
}
