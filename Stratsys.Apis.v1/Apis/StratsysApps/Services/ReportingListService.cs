using Stratsys.Apis.v1.Apis.StratsysApps.Resources;

namespace Stratsys.Apis.v1.Apis.StratsysApps.Services
{
    public class ReportingListService : StratsysClientService
    {
        public ReportingListService(StratsysAuthentication authentication)
            : base(authentication)
        {
            ReportingLists = new ReportingListResource(this);
        }

        public override string Controller
        {
            get { return "stratsys-apps/reportinglists"; }
        }

        public ReportingListResource ReportingLists { get; private set; }
    }
}