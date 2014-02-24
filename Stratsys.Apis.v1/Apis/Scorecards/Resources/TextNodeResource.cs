using Stratsys.Apis.v1.Apis.Scorecards.Requests;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Resources
{
    public class TextNodeResource
    {
        private readonly IClientService m_service;

        public TextNodeResource(IClientService service)
        {
            m_service = service;
        }

        public FilterTextNodesRequest Filter(
            string id = null,
            string departmentId = null,
            string name = null,
            string scorecardId = null)
        {
            return new FilterTextNodesRequest(m_service, id, departmentId, name, scorecardId);
        }
    }
}