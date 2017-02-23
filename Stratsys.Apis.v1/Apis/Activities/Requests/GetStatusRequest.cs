using Stratsys.Apis.v1.Apis.Generics;
using Stratsys.Apis.v1.Dtos.Activities;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Activities.Requests
{
    public class GetStatusRequest: GetRequest<StatusDto>
    {
        public GetStatusRequest(IClientService service, string id)
            : base(service, id)
        {
        }
    }
}