using Stratsys.Apis.v1.Dtos.Organization;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Organization.Requests
{
    public class UpdateUserRequest : StratsysClientRequest<string>
    {
        private readonly UserDto m_user;

        public UpdateUserRequest(IClientService service, UserDto user)
            : base(service)
        {
            m_user = user;
        }

        public override string HttpMethod
        {
            get { return "PUT"; }
        }

        public override object Body
        {
            get { return m_user; }
        }
    }
}