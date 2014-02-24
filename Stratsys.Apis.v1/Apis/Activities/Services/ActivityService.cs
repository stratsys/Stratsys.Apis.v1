using Stratsys.Apis.v1.Apis.Activities.Resources;

namespace Stratsys.Apis.v1.Apis.Activities.Services
{
    public class ActivityService : StratsysClientService
    {
        public ActivityService(string clientId, string clientSecret) : base(clientId, clientSecret)
        {
            Activities = new ActivityResource(this);
        }

        public override string Controller
        {
            get { return "activities"; }
        }

        public ActivityResource Activities { get; private set; }
    }
}