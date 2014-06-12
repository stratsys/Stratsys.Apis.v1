using Stratsys.Apis.v1.Apis.Scorecards.Resources;

namespace Stratsys.Apis.v1.Apis.Scorecards.Services
{
    public class GoalService : StratsysClientService
    {
        public GoalService(StratsysAuthentication authentication)
            : base(authentication)
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