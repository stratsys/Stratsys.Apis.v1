using Stratsys.Apis.v1.Apis.Generics;
using Stratsys.Apis.v1.Dtos.Organization;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Organization.Requests
{
    public class FilterResponsibilityRolesRequest : FilterRequest<ResponsibilityRoleDto>
    {
        public FilterResponsibilityRolesRequest(IClientService service)
            : base(service)
        {
        }

        public FilterResponsibilityRolesRequest(IClientService service, string scorecardColumnId)
            : base(service)
        {
            RequestParameters.Add("scorecardColumnId", scorecardColumnId);
        }

    }
    public class ListResponsibilityRolesRequest : ListRequest<ResponsibilityRoleDto>
    {
        public ListResponsibilityRolesRequest(IClientService service)
            : base(service)
        {
        }

    }
}