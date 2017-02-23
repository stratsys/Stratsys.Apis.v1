using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Generics
{
    public class DeleteRequest<TR> : StratsysClientRequest<TR>
    {
        private readonly string m_id;

        public DeleteRequest(IClientService clientService, string id)
            : base(clientService)
        {
            m_id = id;
        }

        public override string HttpMethod
        {
            get { return "DELETE"; }
        }

        public override string RestPath
        {
            get { return m_id; }
        }

    }
}