using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Activities.Requests
{
    public class CreateSimpleActivityRequest : StratsysClientRequest<string>
    {
        private readonly string m_name;
        private readonly string m_endDate;

        public CreateSimpleActivityRequest(IClientService service, string name, string endDate = null) : base(service)
        {
            m_name = name;
            m_endDate = endDate;
        }

        public override string HttpMethod
        {
            get { return "POST"; }
        }

        public override string RestPath
        {
            get
            {
                var namePath = string.Format("simple/{0}", m_name);
                return !string.IsNullOrEmpty(m_endDate) 
                    ? string.Format("{0}/{1}", namePath, m_endDate) 
                    : namePath;
            }
        }
    }
}