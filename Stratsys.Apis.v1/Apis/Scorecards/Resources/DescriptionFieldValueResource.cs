using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Resources
{
    public class DescriptionFieldValueResource
    {
        private readonly IClientService m_clientService;

        public DescriptionFieldValueResource(IClientService clientService)
        {
            m_clientService = clientService;
        }

        public GetRequest<DescriptionFieldValueDto> Get(string id)
        {
            return new GetRequest<DescriptionFieldValueDto>(m_clientService, id);
        }

        public ListRequest<DescriptionFieldValueDto> List()
        {
            return new ListRequest<DescriptionFieldValueDto>(m_clientService);
        }

        public PutRequest<DescriptionFieldValueDto, DescriptionFieldValueDto> Put(DescriptionFieldValueDto dto)
        {
            return new PutRequest<DescriptionFieldValueDto, DescriptionFieldValueDto>(m_clientService, dto);
        }
    }
}