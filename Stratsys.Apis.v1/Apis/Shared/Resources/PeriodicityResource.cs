using Stratsys.Apis.v1.Apis.Shared.Requests;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Shared.Resources
{
    public class PeriodicityResource
    {
        private readonly IClientService m_service;

        public PeriodicityResource(IClientService service)
        {
            m_service = service;
        }

        public ListPeriodicitiesRequest List()
        {
            return new ListPeriodicitiesRequest(m_service);
        }

        public GetPeriodicityRequest Get(string id)
        {
            return new GetPeriodicityRequest(m_service, id);
        }
    }
}