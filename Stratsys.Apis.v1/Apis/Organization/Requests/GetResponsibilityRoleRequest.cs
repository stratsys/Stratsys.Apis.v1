﻿using Stratsys.Apis.v1.Apis.Generics;
using Stratsys.Apis.v1.Dtos.Organization;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Organization.Requests
{
    public class GetResponsibilityRoleRequest : GetRequest<ResponsibilityRoleDto>
    {

        public GetResponsibilityRoleRequest(IClientService service, string id)
            : base(service,id)
        {
        }

    }
}