using Stratsys.Apis.v1.Apis.Gadgets.Resources;

namespace Stratsys.Apis.v1.Apis.Gadgets.Services
{
    public class ReportingListService : StratsysClientService
    {
        public ReportingListService(string clientId, string clientSecret)
            : base(clientId, clientSecret)
        {
            ReportingLists = new ReportingListResource(this);
        }

        public override string Controller
        {
            get { return "reportingLists"; }
        }

        public ReportingListResource ReportingLists { get; private set; }
    }
}