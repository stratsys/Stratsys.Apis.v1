using Stratsys.Apis.v1.Apis.Activities.Requests;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Activities.Resources
{
    public class ActivityResource
    {
        private readonly IClientService m_service;

        public ActivityResource(IClientService service)
        {
            m_service = service;
        }

        public FilterActivitiesRequest Filter(
            string id = null,
            string departmentId = null,
            string name = null,
            string scorecardId = null,
            string statusId = null
            )
        {
            return new FilterActivitiesRequest(m_service, id, departmentId, name, scorecardId, statusId);
        }
    }
}