using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis
{
    public class GenericService : StratsysClientService
    {
        private readonly string m_controller;

        public GenericService(StratsysAuthentication authentication, string controller)
            : base(authentication)
        {
            m_controller = controller;
        }

        public override string Controller
        {
            get { return m_controller; }
        }
    }

    public class GenericResource<T>
    {
        private readonly IClientService m_service;

        public GenericResource(IClientService service)
        {
            m_service = service;
        }

        public GetRequest<T> Get(string id)
        {
            return new GetRequest<T>(m_service, id);
        }

        public ListRequest<T> List()
        {
            return new ListRequest<T>(m_service);
        }

        public FilterRequest<T> Filter(string name)
        {
            var filterRequest = new FilterRequest<T>(m_service);
            filterRequest.RequestParameters.Add("name", name);
            return filterRequest;
        }

        public PutRequest<T, string> Put(T dto)
        {
            return new PutRequest<T, string>(m_service, dto);
        }

        public PutIdRequest<string> Put(string id)
        {
            return new PutIdRequest<string>(m_service, id);
        }

        public PostRequest<T, string> Post(T dto)
        {
            return new PostRequest<T, string>(m_service, dto);
        }

        public PostIdRequest<string> Post(string id)
        {
            return new PostIdRequest<string>(m_service, id);
        }

        public DeleteRequest<bool> Delete(string id)
        {
            return new DeleteRequest<bool>(m_service, id);
        }
    }
}