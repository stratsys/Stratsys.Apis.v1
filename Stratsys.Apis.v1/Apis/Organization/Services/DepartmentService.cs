using Stratsys.Apis.v1.Apis.Organization.Resources;

namespace Stratsys.Apis.v1.Apis.Organization.Services
{
    public class DepartmentService : StratsysClientService
    {
        public DepartmentService(StratsysAuthentication authentication)
            : base(authentication)
        {
            Departments = new DepartmentResource(this);
        }

        public override string Controller
        {
            get { return "departments"; }
        }

        public DepartmentResource Departments { get; private set; }
    }
}