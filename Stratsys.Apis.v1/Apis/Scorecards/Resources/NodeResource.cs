using Stratsys.Apis.v1.Apis.Scorecards.Requests;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Resources
{
    public class NodeResource
    {
        private readonly IClientService m_service;

        public NodeResource(IClientService service)
        {
            m_service = service;
        }

        public FilterNodesRequest Filter(
            string nodeType = null,
            string id = null,
            string departmentId = null,
            string name = null,
            string scorecardId = null)
        {
            return new FilterNodesRequest(m_service, nodeType, id, departmentId, name, scorecardId);
        }
    }
}