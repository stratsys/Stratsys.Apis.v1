using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Requests
{
    public class ListScorecardsRequest : StratsysClientRequest<List<ScorecardDto>>
    {
        public ListScorecardsRequest(IClientService service)
            : base(service)
        {
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }
    }
}