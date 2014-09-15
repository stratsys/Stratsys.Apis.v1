using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis
{
    public class PutRequest<T> : PutRequest<T, T>
    {
        public PutRequest(IClientService clientService, T dto)
            : base(clientService, dto)
        {
        }
    }

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
}