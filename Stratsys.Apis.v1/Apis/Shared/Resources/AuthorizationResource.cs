using Stratsys.Apis.v1.Apis.Generics;
using Stratsys.Apis.v1.Apis.Shared.Requests;
using Stratsys.Apis.v1.Dtos.Shared;
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

        public GetRequest<ModuleAuthorizationsDto> GetModuleAuthorizations(string userId)
        {
            return new GetRequest<ModuleAuthorizationsDto>(m_service, userId + "/modules");
        }
    }
}