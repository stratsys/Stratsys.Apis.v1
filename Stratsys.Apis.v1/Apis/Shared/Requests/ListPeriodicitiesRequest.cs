using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Shared;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Shared.Requests
{
    public class ListPeriodicitiesRequest : StratsysClientRequest<IList<PeriodicityDto>>
    {
        public ListPeriodicitiesRequest(IClientService service)
            : base(service)
        {
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }
    }
}