using Stratsys.Apis.v1.Apis.Organization.Requests;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Organization.Resources
{
    public class ResponsibilityRoleResource
    {
        private readonly IClientService m_clientService;

        public ResponsibilityRoleResource(IClientService clientService)
        {
            m_clientService = clientService;
        }

        public GetResponsibilityRoleRequest Get(string id)
        {
            return new GetResponsibilityRoleRequest(m_clientService, id);
        }

        public FilterResponsibilityRolesRequest Filter()
        {
            return new FilterResponsibilityRolesRequest(m_clientService);
        }
    }
}