using Microsoft.SqlServer.Server;
using Stratsys.Apis.v1.Apis.Scorecards.Resources;

namespace Stratsys.Apis.v1.Apis.Scorecards.Services
{
    public class ScorecardNodeService : StratsysClientService
    {
        private readonly string m_scorecardId;
        private readonly string m_departmentId;

        public ScorecardNodeService(StratsysAuthentication authentication, string scorecardId, string departmentId)
            : base(authentication)
        {
            m_scorecardId = scorecardId;
            m_departmentId = departmentId;
            Nodes = new ScorecardNodeResource(this);
        }

        public override string Controller
        {
            get { return "scorecards/" + m_scorecardId + "/departments/" + m_departmentId + "/nodes"; }
        }

        public ScorecardNodeResource Nodes { get; private set; }
    }
}