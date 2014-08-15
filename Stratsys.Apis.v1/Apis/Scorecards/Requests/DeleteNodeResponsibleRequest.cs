using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Requests
{
    public class DeleteNodeResponsibleRequest : StratsysClientRequest<int>
    {
        private readonly NodeResponsibleDto m_dto;

        public DeleteNodeResponsibleRequest(IClientService clientService, NodeResponsibleDto dto)
            : base(clientService)
        {
            m_dto = dto;
            RequestParameters.Add("nodeId", dto.NodeId);
            RequestParameters.Add("userId", dto.UserId);
            RequestParameters.Add("responsibilityRoleId", dto.ResponsibilityRoleId);
            RequestParameters.Add("departmentId", dto.DepartmentId);
        }

        public override string HttpMethod
        {
            get { return "DELETE"; }
        }

        public override object Body
        {
            get { return m_dto; }
        }
    }
}