using Stratsys.Apis.v1.Apis.Applications.Requests;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Applications.Resources
{
    public class ApplicationResource
    {
        private readonly IClientService m_clientService;

        public ApplicationResource(IClientService clientService)
        {
            m_clientService = clientService;
        }

        public GetApplicationRequest This()
        {
            return new GetApplicationRequest(m_clientService);
        }

        public SetApplicationVersionRequest SetVersion(string versionId)
        {
            return new SetApplicationVersionRequest(m_clientService, versionId);
        }
    }
}