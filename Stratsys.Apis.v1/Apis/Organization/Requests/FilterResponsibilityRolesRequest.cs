using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Organization;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Organization.Requests
{
    public class FilterResponsibilityRolesRequest : StratsysClientRequest<List<ResponsibilityRoleDto>>
    {
        public FilterResponsibilityRolesRequest(IClientService service)
            : base(service)
        {
        }

        public override string RestPath
        {
            get { return "filter"; }
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }
    }
}