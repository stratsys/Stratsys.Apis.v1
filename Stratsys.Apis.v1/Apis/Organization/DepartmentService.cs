namespace Stratsys.Apis.v1.Apis.Organization
{
    public class DepartmentService : StratsysClientService
    {
        public DepartmentService(string clientId, string clientSecret)
            : base(clientId, clientSecret)
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