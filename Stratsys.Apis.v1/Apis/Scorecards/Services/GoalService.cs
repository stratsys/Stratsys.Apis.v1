using Stratsys.Apis.v1.Apis.Scorecards.Resources;

namespace Stratsys.Apis.v1.Apis.Scorecards.Services
{
    public class GoalService : StratsysClientService
    {
        public GoalService(string clientId, string clientSecret)
            : base(clientId, clientSecret)
        {
            Goals = new GoalResource(this);
        }

        public override string Controller
        {
            get { return "goals"; }
        }

        public GoalResource Goals { get; private set; }
    }
}