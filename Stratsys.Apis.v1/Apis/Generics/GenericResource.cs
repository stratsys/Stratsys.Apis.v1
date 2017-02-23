using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Generics
{
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

        public ListRequest<T> List(params RequestParameter[] parameters)
        {
            var listRequest = new ListRequest<T>(m_service);
            foreach (var parameter in parameters)
            {
                listRequest.RequestParameters.Add(parameter.Name, parameter.Value);
            }
            return listRequest;
        }

        public FilterRequest<T> Filter(string name)
        {
            var filterRequest = new FilterRequest<T>(m_service);
            filterRequest.RequestParameters.Add("name", name);
            return filterRequest;
        }

        public FilterRequest<T> Filter(params RequestParameter[] parameters)
        {
            var filterRequest = new FilterRequest<T>(m_service);
            foreach (var parameter in parameters)
            {
                filterRequest.RequestParameters.Add(parameter.Name, parameter.Value);
            }
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