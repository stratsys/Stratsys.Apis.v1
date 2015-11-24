using Stratsys.Apis.v1.Apis.Scorecards.Requests;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Resources
{
    public class VersionResource
    {
        private readonly IClientService m_clientService;

        public VersionResource(IClientService clientService)
        {
            m_clientService = clientService;
        }

        public ListVersionsRequest List()
        {
            return new ListVersionsRequest(m_clientService);
        }

        public GetVersionRequest Get(string id)
        {
            return new GetVersionRequest(m_clientService, id);
        }
    }
}