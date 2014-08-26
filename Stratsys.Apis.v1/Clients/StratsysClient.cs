using Stratsys.Apis.v1.Apis;
using Stratsys.Apis.v1.Clients.Abstractions;
using Stratsys.Apis.v1.Clients.Resources;
using Stratsys.Apis.v1.Dtos.Scorecards;

namespace Stratsys.Apis.v1.Clients
{
    public class StratsysClient
    {
        private readonly StratsysAuthentication m_authentication;

        public StratsysClient(StratsysAuthentication authentication)
        {
            m_authentication = authentication;
        }

        public StratsysResource<T> Resource<T>(string controller)
        {
            return new StratsysResource<T>(controller, m_authentication);
        }

        public StratsysPath Path(string controller, string id)
        {
            return new StratsysPath(m_authentication, controller, id);
        }

        public StatusDtoResource StatusDtos
        {
            get { return new StatusDtoResource(m_authentication); }
        }

        public StratsysResource<DescriptionFieldDto> DescriptionFields
        {
            get { return new StratsysResource<DescriptionFieldDto>("DescriptionFields", m_authentication); }
        }
    }
}