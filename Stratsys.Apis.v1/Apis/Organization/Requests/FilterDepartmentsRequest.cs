using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Organization;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Organization.Requests
{
    public class FilterDepartmentsRequest : StratsysClientRequest<List<DepartmentDto>>
    {
        public FilterDepartmentsRequest(IClientService service, string name, string parentId)
            : base(service)
        {
            RequestParameters.Add("name", name);
            RequestParameters.Add("parentId", parentId);
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