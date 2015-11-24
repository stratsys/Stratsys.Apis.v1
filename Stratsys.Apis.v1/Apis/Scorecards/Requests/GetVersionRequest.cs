using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Requests
{
    public class GetVersionRequest : StratsysClientRequest<VersionDto>
    {
        private readonly string m_id;

        public GetVersionRequest(IClientService service, string id)
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