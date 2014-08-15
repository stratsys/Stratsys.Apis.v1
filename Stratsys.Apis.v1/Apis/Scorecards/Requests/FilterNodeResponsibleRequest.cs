using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Requests
{
    public class FilterNodeResponsibleRequest : StratsysClientRequest<List<NodeResponsibleDto>>
    {
        public FilterNodeResponsibleRequest(
            IClientService service,
            string nodeId,
            string userId,
            string responsibilityId,
            string departmentId
            )
            : base(service)
        {
            RequestParameters.Add("nodeId", nodeId);
            RequestParameters.Add("departmentId", departmentId);
            RequestParameters.Add("responsibilityRoleId", responsibilityId);
            RequestParameters.Add("userId", userId);
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