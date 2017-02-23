namespace Stratsys.Apis.v1.Apis.Generics
{
    public class GenericService : StratsysClientService
    {
        private readonly string m_controller;

        protected StratsysAuthentication StratsysAuthentication { get; set; }

        public GenericService(StratsysAuthentication stratsysAuthentication, string controller)
            : base(stratsysAuthentication)
        {
            StratsysAuthentication = stratsysAuthentication;
            m_controller = controller;
        }

        public override string Controller
        {
            get { return m_controller; }
        }
    }
}