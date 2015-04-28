using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Activities;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Activities.Requests
{
    public class FilterStatusesRequest : StratsysClientRequest<List<StatusDto>>
    {
        public FilterStatusesRequest(IClientService service, string scorecardColumnId)
            : base(service)
        {
            RequestParameters.Add("scorecardColumnId", scorecardColumnId);
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }

        public override string RestPath
        {
            get { return string.Format("filter"); }
        }
    }
}