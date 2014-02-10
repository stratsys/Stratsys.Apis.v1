using Stratsys.Apis.v1.Dtos;
using Stratsys.Core.Apis.Requests;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis
{
    public abstract class StratsysClientRequest<T> : ClientServiceRequest<StratsysApiMetadata<T>>
    {
        protected StratsysClientRequest(IClientService service)
            : base(service)
        {
        }
    }
}