using Stratsys.Apis.v1.Dtos.Organization;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Organization.Requests
{
    public class DeleteUserRequest : StratsysClientRequest<bool>
    {
        private readonly string m_id;

        public DeleteUserRequest(IClientService service, string id)
            : base(service)
        {
            m_id = id;
        }

        public override string RestPath
        {
            get { return m_id; }
        }

        public override string HttpMethod
        {
            get { return "DELETE"; }
        }
    }
}