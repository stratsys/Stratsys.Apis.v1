namespace Stratsys.Apis.v1.Apis.ResourcePlanning.Me
{
    public class ResourcePlanningMeService
    {
        public ResourcePlanningMeService(StratsysAuthentication authentication)
        {
            Roles = new ResourcePlanningMeRoleResource(authentication);

            Departments = new ResourcePlanningMeDepartmentResource(authentication);
        }

        public ResourcePlanningMeRoleResource Roles { get; set; }

        public ResourcePlanningMeDepartmentResource Departments { get; set; }
    }
}