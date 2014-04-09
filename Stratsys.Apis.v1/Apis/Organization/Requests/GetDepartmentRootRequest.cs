using Stratsys.Apis.v1.Dtos.Organization;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Organization.Requests
{
    public class GetDepartmentRootRequest : StratsysClientRequest<DepartmentDto>
    {
        public GetDepartmentRootRequest(IClientService service)
            : base(service)
        {
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }

        public override string RestPath
        {
            get { return "root"; }
        }
    }
}