using Stratsys.Apis.v1.Apis.Generics;
using Stratsys.Apis.v1.Dtos.Organization;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Resources
{

    public class NodeUserResource
    {
        private readonly IClientService m_clientService;

        public NodeUserResource(IClientService clientService)
        {
            m_clientService = clientService;
        }

        public ListRequest<UserDto> List()
        {
            return new ListRequest<UserDto>(m_clientService);
        }
    }
}