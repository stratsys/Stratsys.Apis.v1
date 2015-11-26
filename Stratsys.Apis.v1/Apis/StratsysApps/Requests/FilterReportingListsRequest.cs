using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Apis.v1.Dtos.StratsysApps;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.StratsysApps.Requests
{
    public class FilterReportingListsRequest : StratsysClientRequest<IList<ReportingListDto>>
    {
        public FilterReportingListsRequest(IClientService service, string name, NodeTypeDto? nodetype, string dashboardId)
            : base(service)
        {
            RequestParameters.Add("name", name);
            RequestParameters.Add("dashboardId", dashboardId);
            if (nodetype != null)
            {
                RequestParameters.Add("nodetype", nodetype.Value + "");
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