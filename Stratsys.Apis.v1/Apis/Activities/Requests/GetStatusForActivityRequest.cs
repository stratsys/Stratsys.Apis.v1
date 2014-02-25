using Stratsys.Apis.v1.Dtos.Activities;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Activities.Requests
{
    public class GetStatusForActivityRequest : StratsysClientRequest<StatusDto>
    {
        private readonly string m_activityId;

        public GetStatusForActivityRequest(
            IClientService clientService,
            string activityId, string departmentId)
            : base(clientService)
        {
            m_activityId = activityId;
            RequestParameters.Add("departmentId", departmentId);
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }

        public override string RestPath
        {
            get { return "status/" + m_activityId; }
        }
    }
}