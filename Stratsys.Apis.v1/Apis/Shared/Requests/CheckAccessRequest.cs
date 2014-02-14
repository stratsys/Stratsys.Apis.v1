using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Shared.Requests
{
    public class CheckAccessRequest : StratsysClientRequest<string>
    {
        public CheckAccessRequest(IClientService service)
            : base(service)
        {
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }

        public override string RestPath
        {
            get { return "CheckAccess"; }
        }
    }
}