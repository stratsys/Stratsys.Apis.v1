using Stratsys.Apis.v1.Dtos.Organization;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Organization.Resources
{
    public class ExternalPageResource
    {
        private readonly IClientService m_service;

        public ExternalPageResource(IClientService service)
        {
            m_service = service;
        }

        public GetRequest<ExternalPageDto> Get(string id)
        {
            return new GetRequest<ExternalPageDto>(m_service, id);
        }

        public ListRequest<ExternalPageDto> List()
        {
            return new ListRequest<ExternalPageDto>(m_service);
        }

        public PostRequest<CreateExternalPageDto, string> Create(CreateExternalPageDto dto)
        {
            return new PostRequest<CreateExternalPageDto, string>(m_service, dto);
        }

        public PutIdRequest<string> ChangeName(string id, string name)
        {
            return new PutIdRequest<string>(m_service, string.Format("{0}/name/{1}", id, name));
        }

        public PutIdRequest<string> ChangeUrl(string id, string url)
        {
            return new PutIdRequest<string>(m_service, string.Format("{0}/url/{1}", id, url));
        }

        public DeleteRequest<bool> Delete(string id)
        {
            return new DeleteRequest<bool>(m_service, id);
        }
    }
}