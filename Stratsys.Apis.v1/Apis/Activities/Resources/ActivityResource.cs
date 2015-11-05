using Stratsys.Apis.v1.Apis.Activities.Requests;
using Stratsys.Apis.v1.Dtos.Activities;
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
            string statusId = null,
            string userId = null,
            bool onlySimple = false,
            bool excludeFinished = false,
            string fields = null
            )
        {
            return new FilterActivitiesRequest(m_service, id, departmentId, name, scorecardId, statusId, userId, onlySimple, excludeFinished, fields);
        }

        public UpdateStatusForActivityRequest SetStatus(string activityId, string statusId)
        {
            return new UpdateStatusForActivityRequest(m_service, activityId, statusId);
        }

        public UpdateEndDateForActivityRequest SetEndDate(string activityId, string endDate)
        {
            return new UpdateEndDateForActivityRequest(m_service, activityId, endDate);
        }

        public GetStatusForActivityRequest GetStatus(string activityId, string departmentId = null)
        {
            return new GetStatusForActivityRequest(m_service, activityId, departmentId);
        }

        public CreateSimpleActivityRequest CreateSimpleActivity(string name, string endDate = null)
        {
            var dto = new SimpleActivityDto
            {
                EndDate = endDate,
                Name = name
            };
            return new CreateSimpleActivityRequest(m_service, dto);
        }
    }
}