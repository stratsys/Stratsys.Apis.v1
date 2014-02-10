using System.Configuration;
using Stratsys.Core.Apis.Services;
using Stratsys.Core.Apis.Services.Authentications;

namespace Stratsys.Apis.v1.Apis
{
    public abstract class StratsysClientService : BaseClientService
    {
        private readonly string m_apiUrl = ConfigurationManager.AppSettings.Get("StratsysApiUrl") ?? "https://www.stratsys.se/api/v1/";

        protected StratsysClientService(string clientId, string clientSecret)
        {
            Authentication = new BasicAuthenticationBuilder().Build(clientId, clientSecret);
        }

        public sealed override string BaseUrl
        {
            get
            {
                return m_apiUrl;
            }
        }
    }
}