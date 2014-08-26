using System.Collections.Generic;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Shared.Requests
{
    public class ListIdMappingTypesRequest : ListRequest<string>
    {
        public ListIdMappingTypesRequest(IClientService service)
            : base(service)
        {
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }

        public override string RestPath
        {
            get { return "mappingTypes"; }
        }
    }
}