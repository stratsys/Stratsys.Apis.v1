using Stratsys.Apis.v1.Dtos.Applications;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Applications.Requests
{
    public class GetApplicationRequest : StratsysClientRequest<ApplicationDto>
    {
        public GetApplicationRequest(IClientService service) : base(service)
        {
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }

        public override string RestPath
        {
            get { return "this"; }
        }
    }
}