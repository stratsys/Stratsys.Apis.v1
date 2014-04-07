using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Shared.Requests
{
    public class DeleteIdMappingRequest : StratsysClientRequest<string>
    {
        private readonly string m_mappingTypeId;
        private readonly string m_externalId;

        public DeleteIdMappingRequest(IClientService service, string mappingTypeId, string externalId)
            : base(service)
        {
            m_mappingTypeId = mappingTypeId;
            m_externalId = externalId;
        }

        public override string HttpMethod
        {
            get { return "DELETE"; }
        }

        public override string RestPath
        {
            get { return m_mappingTypeId + "/" + m_externalId; }
        }
    }
}