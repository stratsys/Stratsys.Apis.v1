using Stratsys.Apis.v1.Apis.Scorecards.Resources;

namespace Stratsys.Apis.v1.Apis.Scorecards.Services
{
    public class ScorecardViewService : StratsysClientService
    {
        public ScorecardViewService(StratsysAuthentication authentication)
            : base(authentication)
        {
            ScorecardViews = new ScorecardViewResource(this);
        }

        public override string Controller
        {
            get { return "scorecardviews"; }
        }

        public ScorecardViewResource ScorecardViews { get; private set; }
    }
}