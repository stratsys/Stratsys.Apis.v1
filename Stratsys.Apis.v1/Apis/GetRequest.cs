using System.Collections.Generic;
using System.Net.Http;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis
{
    public class GetRequest<T> : StratsysClientRequest<T>
    {
        private readonly string m_id;

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

    public class ListRequest<T> : StratsysClientRequest<IList<T>>
    {
        public ListRequest(IClientService service)
            : base(service)
        {
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }

        public override string RestPath
        {
            get { return ""; }
        }

        public IList<T> Result
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

    public class FilterRequest<T> : StratsysClientRequest<IList<T>>
    {
        public FilterRequest(IClientService service)
            : base(service)
        {
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }

        public override string RestPath
        {
            get { return "filter"; }
        }

        public IList<T> Result
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

    public class PostRequest<T> : StratsysClientRequest<string>
    {
        private readonly T m_dto;

        public PostRequest(IClientService clientService, T dto)
            : base(clientService)
        {
            m_dto = dto;
        }

        public override string HttpMethod
        {
            get { return "POST"; }
        }

        public override object Body
        {
            get { return m_dto; }
        }
    }

    public class PutRequest<T> : StratsysClientRequest<string>
    {
        private readonly T m_dto;

        public PutRequest(IClientService clientService, T dto)
            : base(clientService)
        {
            m_dto = dto;
        }

        public override string HttpMethod
        {
            get { return "PUT"; }
        }

        public override object Body
        {
            get { return m_dto; }
        }
    }
}