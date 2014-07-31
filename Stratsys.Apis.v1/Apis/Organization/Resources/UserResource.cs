using Stratsys.Apis.v1.Apis.Organization.Requests;
using Stratsys.Apis.v1.Dtos.Organization;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Organization.Resources
{
    public class UserResource
    {
        private readonly IClientService m_service;

        public UserResource(IClientService service)
        {
            m_service = service;
        }

        public FilterUsersRequest List()
        {
            return Filter();
        }

        public FilterUsersRequest Filter(string email = null, string name = null)
        {
            return new FilterUsersRequest(m_service, email, name);
        }

        public GetUserRequest Get(string id)
        {
            return new GetUserRequest(m_service, id);
        }

        public CreateUserRequest Create(CreateUserDto user)
        {
            return new CreateUserRequest(m_service, user);
        }

        public UpdateUserRequest Update(UserDto user)
        {
            return new UpdateUserRequest(m_service, user);
        }

        public DeleteUserRequest Delete(string id)
        {
            return new DeleteUserRequest(m_service, id);
        }
    }
}