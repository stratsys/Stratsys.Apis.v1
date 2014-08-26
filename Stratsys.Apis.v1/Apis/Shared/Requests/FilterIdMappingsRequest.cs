using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Shared;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Shared.Requests
{
    public class FilterIdMappingsRequest : FilterRequest<IdMapping>
    {
        private readonly string m_mappingTypeId;

        public FilterIdMappingsRequest(IClientService service,
            string mappingTypeId,
            string externalId = null,
            string internalId = null
            )
            : base(service)
        {
            m_mappingTypeId = mappingTypeId;
            RequestParameters.Add("externalId", externalId);
            RequestParameters.Add("internalId", internalId);
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }

        public override string RestPath
        {
            get { return "filter/" + m_mappingTypeId; }
        }
    }
}