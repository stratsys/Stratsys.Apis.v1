using Stratsys.Apis.v1.Apis.Organization.Requests;
using Stratsys.Apis.v1.Dtos.Organization;
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

        public ListRequest<ResponsibilityRoleDto> List()
        {
            return new ListRequest<ResponsibilityRoleDto>(m_clientService);
        }


        public FilterResponsibilityRolesRequest Filter(string scorecardColumnId = null)
        {
            return new FilterResponsibilityRolesRequest(m_clientService, scorecardColumnId);
        }
    }
}