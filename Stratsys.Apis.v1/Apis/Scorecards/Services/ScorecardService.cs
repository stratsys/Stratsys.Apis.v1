using Stratsys.Apis.v1.Apis.Scorecards.Resources;

namespace Stratsys.Apis.v1.Apis.Scorecards.Services
{
    public class ScorecardService : StratsysClientService
    {
        public ScorecardService(string clientId, string clientSecret)
            : base(clientId, clientSecret)
        {
            Scorecards = new ScorecardResource(this);
        }

        public override string Controller
        {
            get { return "scorecards"; }
        }

        public ScorecardResource Scorecards { get; private set; }
    }
}