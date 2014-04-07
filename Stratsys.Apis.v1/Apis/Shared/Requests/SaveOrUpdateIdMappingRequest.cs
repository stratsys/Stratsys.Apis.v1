using Stratsys.Apis.v1.Dtos.Shared;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Shared.Requests
{
    public class SaveOrUpdateIdMappingRequest : StratsysClientRequest<bool?>
    {
        private readonly IdMapping m_idMapping;

        public SaveOrUpdateIdMappingRequest(IClientService service, IdMapping idMapping)
            : base(service)
        {
            m_idMapping = idMapping;
        }

        public override string HttpMethod
        {
            get { return "PUT"; }
        }

        public override object Body
        {
            get { return m_idMapping; }
        }
    }
}