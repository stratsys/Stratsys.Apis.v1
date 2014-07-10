using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Requests
{
    public class FilterGoalsRequest : StratsysClientRequest<IList<GoalDto>>
    {
        public FilterGoalsRequest(IClientService clientService, string id, string departmentId, string name, string scorecardId, string columnId) : base(clientService)
        {
            RequestParameters.Add("id", id);
            RequestParameters.Add("departmentId", departmentId);
            RequestParameters.Add("name", name);
            RequestParameters.Add("scorecardId", scorecardId);
            RequestParameters.Add("columnId", columnId);
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }

        public override string RestPath
        {
            get { return "filter"; }
        }
    }
}