using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Requests
{
    public class FilterScorecardColumnsRequest : FilterRequest<ScorecardColumnDto>
    {
        public FilterScorecardColumnsRequest(
            IClientService service,
            string scorecardId,
            string name,
            int? index,
            NodeTypeDto? nodeType
            )
            : base(service)
        {
            RequestParameters.Add("scorecardId", scorecardId);
            RequestParameters.Add("name", name);
            if (index.HasValue)
            {
                RequestParameters.Add("index", index + "");
            } 
            if (nodeType.HasValue)
            {
                RequestParameters.Add("nodeType", nodeType + "");
            }
        }
    }
}