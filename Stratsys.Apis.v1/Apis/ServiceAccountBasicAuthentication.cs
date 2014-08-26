using System.Net.Http.Headers;
using Stratsys.Core.Apis.Services.Authentications;

namespace Stratsys.Apis.v1.Apis
{
    public class ServiceAccountBasicAuthentication : StratsysAuthentication
    {
        private readonly string m_clientId;
        private readonly string m_clientSecret;

        public ServiceAccountBasicAuthentication(string clientId, string clientSecret)
        {
            m_clientId = clientId;
            m_clientSecret = clientSecret;
        }

        public override AuthenticationHeaderValue AuthenticationHeaderValue
        {
            get { return new BasicAuthenticationBuilder().Build(m_clientId, m_clientSecret); }
        }
    }
}