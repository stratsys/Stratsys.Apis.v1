using Stratsys.Apis.v1.Apis.Generics;
using Stratsys.Apis.v1.Dtos.Organization;

namespace Stratsys.Apis.v1.Apis.ResourcePlanning.Me
{
    public sealed class ResourcePlanningMeDepartmentResource
    {
        private readonly GenericResource<DepartmentDto> m_resource;

        public ResourcePlanningMeDepartmentResource(StratsysAuthentication authentication)
        {
            var roleService = new GenericService(authentication, "resourceplanning/me/departments");
            m_resource = new GenericResource<DepartmentDto>(roleService);
        }

        public GetRequest<DepartmentDto> Get(string departmentId) => 
            m_resource.Get(departmentId);

        public ListRequest<DepartmentDto> List() => 
            m_resource.List();
    }
}