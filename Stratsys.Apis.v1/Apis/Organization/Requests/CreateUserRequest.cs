using Stratsys.Apis.v1.Dtos.Organization;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Organization.Requests
{
    public class CreateUserRequest : StratsysClientRequest<string>
    {
        private readonly CreateUserDto m_user;

        public CreateUserRequest(IClientService service, CreateUserDto user)
            : base(service)
        {
            m_user = user;
        }

        public override string HttpMethod
        {
            get { return "POST"; }
        }

        public override object Body
        {
            get { return m_user; }
        }
    }
}