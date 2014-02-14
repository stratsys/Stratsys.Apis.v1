using Stratsys.Apis.v1.Dtos.Shared;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Shared.Requests
{
    public class GetPeriodicityRequest : StratsysClientRequest<PeriodicityDto>
    {
        private readonly string m_id;

        public GetPeriodicityRequest(IClientService service, string id)
            : base(service)
        {
            m_id = id;
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }

        public override string RestPath
        {
            get { return m_id; }
        }
    }
}