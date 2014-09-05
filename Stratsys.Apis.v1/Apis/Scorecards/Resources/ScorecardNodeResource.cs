using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Resources
{
    public class ScorecardNodeResource
    {
        private readonly IClientService m_clientService;

        public ScorecardNodeResource(IClientService clientService)
        {
            m_clientService = clientService;
        }

        public GetRequest<ScorecardNodeDto> GetRoot()
        {
            return new GetRequest<ScorecardNodeDto>(m_clientService, "root");
        }

        public GetRequest<ScorecardNodeDto> Get(string id)
        {
            return new GetRequest<ScorecardNodeDto>(m_clientService, id);
        }

        public GetRequest<ScorecardNodeDto> Get(string id, string fields)
        {
            var getRequest = new GetRequest<ScorecardNodeDto>(m_clientService, id);
            getRequest.RequestParameters.Add("fields",fields);
            return getRequest;
        }

        public ListRequest<ScorecardNodeDto> List()
        {
            return new ListRequest<ScorecardNodeDto>(m_clientService);
        }

        public FilterRequest<ScorecardNodeDto> Filter()
        {
            var filterRequest = new FilterRequest<ScorecardNodeDto>(m_clientService);
            return filterRequest;
        }

        public FilterRequest<ScorecardNodeDto> Filter(string name)
        {
            var filterRequest = new FilterRequest<ScorecardNodeDto>(m_clientService);
            filterRequest.RequestParameters.Add("name",name);
            return filterRequest;
        }

        public PutRequest<PutNodeDto,string> Put(PutNodeDto dto)
        {
            return new PutRequest<PutNodeDto,string>(m_clientService, dto);
        }

        public PostRequest<PostNodeDto> Post(PostNodeDto dto)
        {
            return new PostRequest<PostNodeDto>(m_clientService, dto);
        }

    }
}