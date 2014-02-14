using Stratsys.Apis.v1.Apis.Shared.Requests;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Shared.Resources
{
    public class AuthorizationResource
    {
        private readonly IClientService m_service;

        public AuthorizationResource(IClientService service)
        {
            m_service = service;
        }

        public CheckAccessRequest CheckAccess()
        {
            return new CheckAccessRequest(m_service);
        }
    }
}