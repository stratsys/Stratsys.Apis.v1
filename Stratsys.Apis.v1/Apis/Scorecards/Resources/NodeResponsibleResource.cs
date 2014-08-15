using Stratsys.Apis.v1.Apis.Scorecards.Requests;
using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Resources
{
    public class NodeResponsibleResource
    {
        private readonly IClientService m_clientService;

        public NodeResponsibleResource(IClientService clientService)
        {
            m_clientService = clientService;
        }

        public FilterNodeResponsibleRequest Filter(NodeResponsibleDto filter)
        {
            return new FilterNodeResponsibleRequest(m_clientService,
                filter.NodeId, filter.UserId, filter.ResponsibilityRoleId, filter.DepartmentId);
        }

        public CreateNodeResponsibleRequest Create(NodeResponsibleDto filter)
        {
            return new CreateNodeResponsibleRequest(m_clientService, filter);
        }

        public DeleteNodeResponsibleRequest Delete(NodeResponsibleDto filter)
        {
            return new DeleteNodeResponsibleRequest(m_clientService, filter);
        }
    }
}