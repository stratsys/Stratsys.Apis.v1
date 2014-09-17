using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis
{
    //public class PostRequest<T> : PostRequest<T, string>
    //{
    //    public PostRequest(IClientService clientService, T dto)
    //        : base(clientService, dto)
    //    {
    //    }
    //}

    public class PostRequest<T, TR> : StratsysClientRequest<TR>
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

    public class PostIdRequest<TR> : StratsysClientRequest<TR>
    {
        private readonly string m_id;

        public PostIdRequest(IClientService clientService, string id)
            : base(clientService)
        {
            m_id = id;
        }

        public override string HttpMethod
        {
            get { return "POST"; }
        }

        public override string RestPath
        {
            get { return m_id; }
        }
    }

}