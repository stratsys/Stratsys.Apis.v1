using Stratsys.Apis.v1.Dtos.Organization;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards
{
    public class ScorecardsDepartmentsNodesResponsibilityRolesPath
    {
        private readonly IClientService m_nodeUserService;

        public ScorecardsDepartmentsNodesResponsibilityRolesPath(
            StratsysAuthentication authentication,
            Path path)
        {
            m_nodeUserService = new GenericService(authentication, path.Resource("users").Build());
        }

        public GenericResource<UserDto> Users
        {
            get { return new GenericResource<UserDto>(m_nodeUserService); }
        }

    }
}