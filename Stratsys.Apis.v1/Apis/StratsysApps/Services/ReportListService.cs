using Stratsys.Apis.v1.Apis.StratsysApps.Resources;

namespace Stratsys.Apis.v1.Apis.StratsysApps.Services
{
    public class ReportListService : StratsysClientService
    {
        public ReportListService(StratsysAuthentication authentication)
            : base(authentication)
        {
            ReportLists = new ReportListResource(this);
        }

        public override string Controller
        {
            get { return "stratsys-apps/reportlists"; }
        }

        public ReportListResource ReportLists { get; private set; }
    }
}