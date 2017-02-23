using Stratsys.Apis.v1.Apis.Generics;

namespace Stratsys.Apis.v1.Apis.ResourcePlanning.Me
{
    public sealed class ResourcePlanningMeRoleResource
    {
        private readonly GenericResource<string> m_resource;

        public ResourcePlanningMeRoleResource(StratsysAuthentication authentication)
        {
            var roleService = new GenericService(authentication, "resourceplanning/me/roles");
            m_resource = new GenericResource<string>(roleService);
        }

        public ListRequest<string> OnDepartment(string departmentId) => 
            m_resource.List(new RequestParameter(nameof(departmentId), departmentId));

        public FilterRequest<string> FilterDepartment(string departmentId) => 
            m_resource.Filter(new RequestParameter(nameof(departmentId), departmentId));
    }
}