using Stratsys.Apis.v1.Apis.Organization.Resources;

namespace Stratsys.Apis.v1.Apis.Organization.Services
{
    public class ResponsibilityRoleService : StratsysClientService
    {
        public ResponsibilityRoleService(StratsysAuthentication authentication)
            : base(authentication)
        {
            ResponsibilityRoles = new ResponsibilityRoleResource(this);
        }


        public override string Controller
        {
            get { return "responsibilityroles"; }
        }

        public ResponsibilityRoleResource ResponsibilityRoles { get; private set; }
    }
}