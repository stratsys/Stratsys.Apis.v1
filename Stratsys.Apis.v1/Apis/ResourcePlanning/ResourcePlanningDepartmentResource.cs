using Stratsys.Apis.v1.Apis.Generics;
using Stratsys.Apis.v1.Dtos.Organization;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.ResourcePlanning
{
    public class ResourcePlanningDepartmentResource
    {
        private readonly GenericResource<DepartmentDto> m_genericResource;

        public ResourcePlanningDepartmentResource(IClientService service)
        {
            m_genericResource = new GenericResource<DepartmentDto>(service);
        }

        public GetRequest<DepartmentDto> Get(string departmentId)
        {
            return m_genericResource.Get(departmentId);
        }

        public ListRequest<DepartmentDto> List()
        {
            return m_genericResource.List();
        }
    }
}