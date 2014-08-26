using Stratsys.Apis.v1.Apis;

namespace Stratsys.Apis.v1.Clients.Abstractions
{
    public class StratsysPath
    {
        private readonly StratsysAuthentication m_authentication;
        private readonly string m_local;

        public StratsysPath(StratsysAuthentication authentication, string controller, string id)
        {
            m_authentication = authentication;
            m_local = controller + "/" + id + "/";
        }

        public StratsysAuthentication Authentication
        {
            get { return m_authentication; }
        }

        public StratsysPath Path(string controller, string id)
        {
            return new StratsysPath(m_authentication, m_local + controller, id);
        }

        public StratsysResource<T> Resource<T>(string controller)
        {
            return new StratsysResource<T>(m_local + controller, Authentication);
        }
    }
}