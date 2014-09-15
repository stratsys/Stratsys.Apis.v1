using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis
{
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
}