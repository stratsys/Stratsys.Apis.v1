using System.Configuration;
using System.Net.Http.Headers;
using Stratsys.Core.Apis.Services;
using Stratsys.Core.Apis.Services.Authentications;

namespace Stratsys.Apis.v1.Apis
{
    public abstract class StratsysClientService : BaseClientService
    {
        private readonly string m_apiUrl = ConfigurationManager.AppSettings.Get("StratsysApiUrl") ?? "https://www.stratsys.se/api/v1/";
        protected StratsysClientService(StratsysAuthentication authentication)
        {
            Authentication = authentication.AuthenticationHeaderValue;
        }

        public sealed override string BaseUrl
        {
            get
            {
                return m_apiUrl;
            }
        }
    }

    public abstract class StratsysAuthentication
    {
        public abstract AuthenticationHeaderValue AuthenticationHeaderValue { get; }
    }

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

    public class OauthBearerAuthentication : StratsysAuthentication
    {
        private readonly string m_token;

        public OauthBearerAuthentication(string token)
        {
            m_token = token;
        }

        public override AuthenticationHeaderValue AuthenticationHeaderValue
        {
            get
            {
                return new AuthenticationHeaderValue("BEARER", m_token);
            }
        }
    }
}