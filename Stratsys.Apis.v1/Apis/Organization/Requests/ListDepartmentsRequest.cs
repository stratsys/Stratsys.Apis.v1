using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Organization;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Organization.Requests
{
    public class ListDepartmentsRequest : StratsysClientRequest<List<DepartmentDto>>
    {
        public ListDepartmentsRequest(IClientService service)
            : base(service)
        {
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }
    }
}