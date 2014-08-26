using System.Collections.Generic;
using Stratsys.Apis.v1.Apis;
using Stratsys.Apis.v1.Clients.Abstractions;
using Stratsys.Apis.v1.Dtos.Activities;

namespace Stratsys.Apis.v1.Clients.Resources
{
    public class StatusDtoResource
    {
        private readonly StratsysResource<StatusDto> m_resource;

        public StatusDtoResource(StratsysAuthentication authentication)
        {
            m_resource = new StratsysResource<StatusDto>("statuses", authentication);
        }

        public StatusDto Get(string id)
        {
            return m_resource.Get(id);
        }

        public IList<StatusDto> List()
        {
            return m_resource.List();
        }
    }
}