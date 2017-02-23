using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Generics
{
    public class PutRequest<T, TR> : StratsysClientRequest<TR>
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

    public class PutIdRequest<TR> : StratsysClientRequest<TR>
    {
        private readonly string m_id;

        public PutIdRequest(IClientService clientService, string id)
            : base(clientService)
        {
            m_id = id;
        }

        public override string HttpMethod
        {
            get { return "PUT"; }
        }

        public override string RestPath
        {
            get { return m_id; }
        }
    }
}