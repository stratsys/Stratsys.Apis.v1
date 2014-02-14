using Stratsys.Apis.v1.Apis.Organization.Requests;
using Stratsys.Apis.v1.Dtos.Organization;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Organization.Resources
{
    public class DepartmentResource
    {
        private readonly IClientService m_service;

        public DepartmentResource(IClientService service)
        {
            m_service = service;
        }

        public ListDepartmentsRequest List()
        {
            return new ListDepartmentsRequest(m_service);
        }

        public FilterDepartmentsRequest Filter(string name = null, string parentId = null)
        {
            return new FilterDepartmentsRequest(m_service, name, parentId);
        }

        public GetDepartmentRequest Get(string id)
        {
            return new GetDepartmentRequest(m_service, id);
        }

        public SaveOrUpdateDepartmentRequest SaveOrUpdate(DepartmentDto department)
        {
            return new SaveOrUpdateDepartmentRequest(m_service, department);
        }
    }
}