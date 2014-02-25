using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Gadgets;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Gadgets.Requests
{
    public class ListReportingListsRequest : StratsysClientRequest<IList<ReportingListDto>>
    {
        public ListReportingListsRequest(IClientService service)
            : base(service)
        {
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }
    }
}