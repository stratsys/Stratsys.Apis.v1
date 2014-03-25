using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Organization;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Organization.Requests
{
    public class ListGroupsRequest : StratsysClientRequest<List<GroupDto>>
    {
        public ListGroupsRequest(IClientService service)
            : base(service)
        {
        }

        public override string RestPath
        {
            get { return ""; }
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }
    }
}