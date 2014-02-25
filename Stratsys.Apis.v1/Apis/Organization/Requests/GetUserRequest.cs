using Stratsys.Apis.v1.Dtos.Organization;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Organization.Requests
{
    public class GetUserRequest : StratsysClientRequest<UserDto>
    {
        private readonly string m_id;

        public GetUserRequest(IClientService service, string id)
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
            get { return "GET"; }
        }
    }
}