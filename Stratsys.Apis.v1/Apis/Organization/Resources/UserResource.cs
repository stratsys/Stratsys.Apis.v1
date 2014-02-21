using Stratsys.Apis.v1.Apis.Organization.Requests;
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
    }
}