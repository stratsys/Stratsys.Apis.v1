using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Requests
{
    public class CreateGoalRequest : StratsysClientRequest<string>
    {
        private readonly CreateGoalDto m_dto;

        public CreateGoalRequest(IClientService clientService, CreateGoalDto dto)
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