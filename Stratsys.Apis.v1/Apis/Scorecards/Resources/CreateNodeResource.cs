using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Resources
{
    public class CreateNodeResource
    {
        private readonly IClientService m_clientService;

        public CreateNodeResource(IClientService clientService)
        {
            m_clientService = clientService;
        }

        public PostRequest<ScorecardNodeDto> Put(ScorecardNodeDto dto)
        {
            return new PostRequest<ScorecardNodeDto>(m_clientService, dto);
        }
    }
}