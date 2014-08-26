using Stratsys.Apis.v1.Apis.Activities.Requests;
using Stratsys.Apis.v1.Dtos.Activities;
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

        public GetRequest<StatusDto> Get(string id)
        {
            return new GetRequest<StatusDto>(m_service, id);
        }

        public ListStatusesRequest List()
        {
            return new ListStatusesRequest(m_service);
        }
    }
}