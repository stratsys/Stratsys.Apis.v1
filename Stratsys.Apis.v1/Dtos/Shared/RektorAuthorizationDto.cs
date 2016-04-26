using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Organization;

namespace Stratsys.Apis.v1.Dtos.Shared
{
    public class RektorAuthorizationDto
    {
        public bool IsAuthorized { get; set; }
        public IList<DepartmentDto> AuthorizedDepartments { get; set; }
    }
}