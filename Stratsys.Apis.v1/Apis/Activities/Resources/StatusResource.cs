using Stratsys.Apis.v1.Apis.Activities.Requests;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Activities.Resources
{
    public class StatusResource
    {
        private readonly IClientService m_service;

        public StatusResource(IClientService service)
        {
            m_service = service;
        }

        public GetStatusRequest Get(string id)
        {
            return new GetStatusRequest(m_service, id);
        }

        public ListStatusesRequest List()
        {
            return new ListStatusesRequest(m_service);
        }
    }
}