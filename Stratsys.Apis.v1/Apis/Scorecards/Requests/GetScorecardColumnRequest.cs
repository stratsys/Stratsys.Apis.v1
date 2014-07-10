using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Requests
{
    public class GetScorecardColumnRequest : StratsysClientRequest<ScorecardColumnDto>
    {
        private readonly string _id;

        public GetScorecardColumnRequest(IClientService service, string id)
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