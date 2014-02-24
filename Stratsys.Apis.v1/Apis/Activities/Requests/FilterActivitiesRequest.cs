using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Activities;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Activities.Requests
{
    public class FilterActivitiesRequest: StratsysClientRequest<IList<ActivityDto>>
    {
        public FilterActivitiesRequest(
            IClientService clientService, 
            string id, 
            string departmentId, 
            string name, 
            string scorecardId,
            string statusId
            ) : base(clientService)
        {
            RequestParameters.Add("id", id);
            RequestParameters.Add("departmentId", departmentId);
            RequestParameters.Add("name", name);
            RequestParameters.Add("scorecardId", scorecardId);
            RequestParameters.Add("statusId", statusId);
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