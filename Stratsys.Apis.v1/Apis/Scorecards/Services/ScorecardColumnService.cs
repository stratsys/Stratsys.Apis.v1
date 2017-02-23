using Stratsys.Apis.v1.Apis.Scorecards.Resources;

namespace Stratsys.Apis.v1.Apis.Scorecards.Services
{
    public class ScorecardColumnService : StratsysClientService
    {
        private readonly StratsysAuthentication m_stratsysAuthentication;

        public ScorecardColumnService(StratsysAuthentication authentication)
            : base(authentication)
        {
            m_stratsysAuthentication = authentication;
            ScorecardColumns = new ScorecardColumnResource(this);
        }

        public override string Controller
        {
            get { return "scorecardcolumns"; }
        }

        public ScorecardColumnResource ScorecardColumns { get; private set; }
    }

}