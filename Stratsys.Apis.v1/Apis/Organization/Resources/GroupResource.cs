using Stratsys.Apis.v1.Apis.Organization.Requests;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Organization.Resources
{
    public class GroupResource
    {
        private readonly IClientService m_service;

        public GroupResource(IClientService service)
        {
            m_service = service;
        }

        public ListGroupsRequest List()
        {
            return new ListGroupsRequest(m_service);
        }

        public GetGroupRequest Get(string id)
        {
            return new GetGroupRequest(m_service, id);
        }
    }
}