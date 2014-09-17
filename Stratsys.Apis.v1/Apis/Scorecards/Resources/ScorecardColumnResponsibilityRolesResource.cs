using Stratsys.Apis.v1.Dtos.Organization;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Resources
{
    public class ScorecardColumnResponsibilityRolesResource
    {
        private readonly IClientService m_service;

        public ScorecardColumnResponsibilityRolesResource(IClientService service)
        {
            m_service = service;
        }

        public ListRequest<ResponsibilityRoleDto> List()
        {
             return new ListRequest<ResponsibilityRoleDto>(m_service); 
        }

    }
}