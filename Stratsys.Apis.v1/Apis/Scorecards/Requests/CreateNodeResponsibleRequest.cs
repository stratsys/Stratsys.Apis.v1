using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Requests
{
    public class CreateNodeResponsibleRequest : StratsysClientRequest<int>
    {
        private readonly NodeResponsibleDto m_dto;

        public CreateNodeResponsibleRequest(IClientService clientService, NodeResponsibleDto dto)
            : base(clientService)
        {
            m_dto = dto;
        }

        public override string HttpMethod
        {
            get { return "POST"; }
        }

        public override object Body
        {
            get { return m_dto; }
        }
    }
}

