using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Activities;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Activities.Requests
{
    public class ListStatusesRequest: StratsysClientRequest<List<StatusDto>>
    {
        public ListStatusesRequest(IClientService service)
            : base(service)
        {
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }
    }
}