using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Resources
{
    public class NodeKeywordResource
    {
        private readonly IClientService m_clientService;

        public NodeKeywordResource(IClientService clientService)
        {
            m_clientService = clientService;
        }

        public GetRequest<KeywordDto> Get(string id)
        {
            return new GetRequest<KeywordDto>(m_clientService, id);
        }

        public ListRequest<KeywordDto> List()
        {
            return new ListRequest<KeywordDto>(m_clientService);
        }

        public PutRequest<KeywordDto> Put(KeywordDto dto)
        {
            return new PutRequest<KeywordDto>(m_clientService, dto);
        }

        public DeleteRequest<bool> Delete(string id)
        {
            return new DeleteRequest<bool>(m_clientService, id);
        }
    }
}