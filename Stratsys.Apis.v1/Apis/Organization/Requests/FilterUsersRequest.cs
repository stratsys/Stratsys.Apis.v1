﻿using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Organization;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Organization.Requests
{
    public class FilterUsersRequest : StratsysClientRequest<List<UserDto>>
    {
        public FilterUsersRequest(IClientService service, string email, string name)
            : base(service)
        {
            RequestParameters.Add("email", email);
            RequestParameters.Add("name", name);
        }

        public override string RestPath
        {
            get { return "filter"; }
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }
    }
}