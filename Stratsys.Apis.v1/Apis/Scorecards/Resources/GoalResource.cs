using Stratsys.Apis.v1.Apis.Scorecards.Requests;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Resources
{
    public class GoalResource
    {
        private readonly IClientService m_service;

        public GoalResource(IClientService service)
        {
            m_service = service;
        }

        public FilterGoalsRequest Filter(
            string id = null,
            string departmentId = null,
            string name = null,
            string scorecardId = null,
            string columnId = null
            )
        {
            return new FilterGoalsRequest(m_service, id, departmentId, name, scorecardId, columnId);
        }
    }
}