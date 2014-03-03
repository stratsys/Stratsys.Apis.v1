using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Gadgets;
using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Gadgets.Requests
{
    public class FilterReportingListsRequest : StratsysClientRequest<IList<ReportingListDto>>
    {
        public FilterReportingListsRequest(IClientService service, string name, NodeTypeDto? nodetype)
            : base(service)
        {
            RequestParameters.Add("name", name);
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