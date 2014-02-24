using Stratsys.Apis.v1.Apis.Activities.Resources;

namespace Stratsys.Apis.v1.Apis.Activities.Services
{
    public class StatusService : StratsysClientService
    {
        public StatusService(string clientId, string clientSecret) : base(clientId, clientSecret)
        {
            Statuses = new StatusResource(this);
        }

        public override string Controller
        {
            get { return "statuses"; }
        }

        public StatusResource Statuses { get; private set; }
    }
}