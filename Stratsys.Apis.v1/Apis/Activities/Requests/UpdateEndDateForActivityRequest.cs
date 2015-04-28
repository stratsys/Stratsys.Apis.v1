using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Activities.Requests
{
    public class UpdateEndDateForActivityRequest : StratsysClientRequest<string>
    {
        private readonly string m_id;
        private readonly string m_endDate;

        public UpdateEndDateForActivityRequest(IClientService clientService, string id, string endDate)
            : base(clientService)
        {
            m_id = id;
            m_endDate = endDate;
        }

        public override string HttpMethod
        {
            get { return "PUT"; }
        }

        public override string RestPath
        {
            get { return string.Format("{0}/enddate/{1}", m_id, m_endDate); }
        }
    }
}