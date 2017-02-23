using System.Net.Http;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Generics
{
    public class GetRequest<T> : StratsysClientRequest<T>
    {
        private readonly string m_id;

        public GetRequest(IClientService service)
            : base(service)
        {
        }

        public GetRequest(IClientService service, string id)
            : base(service)
        {
            m_id = id;
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }

        public override string RestPath
        {
            get { return m_id; }
        }


        public T Result
        {
            get
            {
                var metadata = Fetch();
                if (!metadata.Success)
                {
                    throw new HttpRequestException(metadata.Message);
                }
                return metadata.Result;
            }
        }
    }

}