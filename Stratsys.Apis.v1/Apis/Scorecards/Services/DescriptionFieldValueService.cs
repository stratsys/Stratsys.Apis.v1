using Stratsys.Apis.v1.Apis.Scorecards.Resources;

namespace Stratsys.Apis.v1.Apis.Scorecards.Services
{
    public class DescriptionFieldValueService : StratsysClientService
    {
        private readonly string m_scorecardId;
        private readonly string m_departmentId;
        private readonly string m_nodeId;

        public DescriptionFieldValueService(StratsysAuthentication authentication,
            string scorecardId, string departmentId, string nodeId)
            : base(authentication)
        {
            m_scorecardId = scorecardId;
            m_departmentId = departmentId;
            m_nodeId = nodeId;
            DescriptionFieldsValue = new DescriptionFieldValueResource(this);
        }

        public override string Controller
        {
            get
            {
                return string.Format("scorecards/{0}/departments/{1}/nodes/{2}/Descriptionfields",
                    m_scorecardId, m_departmentId, m_nodeId);
            }
        }

        public DescriptionFieldValueResource DescriptionFieldsValue { get; private set; }

    }
}