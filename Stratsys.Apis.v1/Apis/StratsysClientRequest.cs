using System.Net.Http;
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

        //public new StratsysApiMetadata<T> Fetch()
        //{
        //    var metadata = base.Fetch();
        //    if (!metadata.Success)
        //    {
        //        throw new HttpRequestException(metadata.Message);
        //    }
        //    return metadata;
        //}

        //public T Result
        //{
        //    get
        //    {
        //        return GetResult();
        //    }
        //}

        //public T GetResult()
        //{
        //    var metadata = Fetch();
        //    if (!metadata.Success)
        //    {
        //        throw new HttpRequestException(metadata.Message);
        //    }
        //    return metadata.Result;
        //    return Fetch().Result;
        //}

    }
}
