using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Resources
{
    public class NodeExternalPageResource
    {
        private readonly IClientService m_clientService;

        public NodeExternalPageResource(IClientService clientService)
        {
            m_clientService = clientService;
        }

        public ListRequest<NodeExternalPageDto> List()
        {
            return new ListRequest<NodeExternalPageDto>(m_clientService);
        }

        public DeleteRequest<bool> Delete(string externalPageId)
        {
            return new DeleteRequest<bool>(m_clientService, externalPageId);
        }

        public PutIdRequest<string> Put(string externalPageId, string urlSuffix = "")
        {
            var putIdRequest = new PutIdRequest<string>(m_clientService, externalPageId);
            putIdRequest.RequestParameters.Add("urlSuffix", urlSuffix);
            return putIdRequest;
        }
    }
}