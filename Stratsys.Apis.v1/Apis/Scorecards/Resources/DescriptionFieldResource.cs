using Stratsys.Apis.v1.Apis.Scorecards.Requests;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Resources
{
    public class DescriptionFieldResource
    {
        private readonly IClientService m_clientService;

        public DescriptionFieldResource(IClientService clientService)
        {
            m_clientService = clientService;
        }

        public GetDescriptionFieldRequest Get(string id)
        {
            return new GetDescriptionFieldRequest(m_clientService, id);
        }

        public FilterDescriptionFieldRequest Filter(string scorecardColumnId = null)
        {
            return new FilterDescriptionFieldRequest(m_clientService, scorecardColumnId);
        }
    }
}