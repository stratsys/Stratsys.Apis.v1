using Stratsys.Apis.v1.Dtos.Organization;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Organization.Requests
{
    public class GetDepartmentRequest : StratsysClientRequest<DepartmentDto>
    {
        private readonly string _id;

        public GetDepartmentRequest(IClientService service, string id)
            : base(service)
        {
            _id = id;
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }

        public override string RestPath
        {
            get { return _id; }
        }
    }
}