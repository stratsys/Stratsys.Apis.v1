using Stratsys.Apis.v1.Apis.Generics;
using Stratsys.Apis.v1.Apis.ResourcePlanning.Me;
using Stratsys.Apis.v1.Dtos.Shared;

namespace Stratsys.Apis.v1.Apis.ResourcePlanning
{
    public sealed class ResourcePlanningService
    {
        public ResourcePlanningService(StratsysAuthentication authentication)
        {
            Departments = new ResourcePlanningDepartmentResource(
                new GenericService(authentication, "resourceplanning/departments"));

            Roles = new ResourcePlanningRoleResource<EntityDto>(
                new GenericService(authentication, "resourceplanning/roles"));


            Me = new ResourcePlanningMeService(authentication);
        }

        public ResourcePlanningDepartmentResource Departments { get; private set; }

        public ResourcePlanningRoleResource<EntityDto> Roles { get; private set; }

        public ResourcePlanningMeService Me { get; private set; }
    }
}