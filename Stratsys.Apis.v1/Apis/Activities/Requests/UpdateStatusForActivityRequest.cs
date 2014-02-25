using Stratsys.Apis.v1.Dtos.Activities;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Activities.Requests
{
    public class UpdateStatusForActivityRequest : StratsysClientRequest<string>
    {
        private readonly UpdateStatusDto m_updateStatusDto;

        public UpdateStatusForActivityRequest(IClientService clientService, UpdateStatusDto updateStatusDto)
            : base(clientService)
        {
            m_updateStatusDto = updateStatusDto;
        }

        public override string HttpMethod
        {
            get { return "PUT"; }
        }

        public override object Body
        {
            get { return m_updateStatusDto; }
        }

        public override string RestPath
        {
            get { return "status"; }
        }
    }
}