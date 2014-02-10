using Stratsys.Apis.v1.Dtos.Organization;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Organization.Requests
{
    public class SaveOrUpdateDepartmentRequest : StratsysClientRequest<DepartmentDto>
    {
        private readonly DepartmentDto m_department;

        public SaveOrUpdateDepartmentRequest(IClientService service, DepartmentDto department)
            : base(service)
        {
            m_department = department;
        }

        public override string HttpMethod
        {
            get { return "PUT"; }
        }

        public override object Body
        {
            get
            {
                return m_department;
            }
        }
    }
}