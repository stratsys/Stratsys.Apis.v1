using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Activities;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Activities.Requests
{
    public class FilterActivitiesRequest : StratsysClientRequest<IList<ActivityDto>>
    {
        public FilterActivitiesRequest(
            IClientService clientService,
            string id,
            string departmentId,
            string name,
            string scorecardId,
            string statusId,
            string userId,
            bool onlySimple,
            bool excludeFinished,
            string fields
            )
            : base(clientService)
        {
            RequestParameters.Add("id", id);
            RequestParameters.Add("departmentId", departmentId);
            RequestParameters.Add("name", name);
            RequestParameters.Add("scorecardId", scorecardId);
            RequestParameters.Add("statusId", statusId);
            RequestParameters.Add("userId", userId);
            RequestParameters.Add("onlySimple", onlySimple.ToString());
            RequestParameters.Add("excludeFinished", excludeFinished.ToString());
            if (fields != null)
            {
                RequestParameters.Add("fields", fields);
            }
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