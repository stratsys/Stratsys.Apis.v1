using System.Configuration;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis
{
    public abstract class StratsysClientService : BaseClientService
    {
        private readonly string m_apiBaseUrl;
        private const string DefaultApiBaseUrl = "https://www.stratsys.se/api/v1/";

        protected StratsysClientService(StratsysAuthentication stratsysAuthentication)
        {
            Authentication = stratsysAuthentication.AuthenticationHeaderValue;
            m_apiBaseUrl = GetApiBaseUrl(stratsysAuthentication);
        }

        private string GetApiBaseUrl(StratsysAuthentication stratsysAuthentication)
        {
            if (string.IsNullOrEmpty(stratsysAuthentication.ApiBaseUrl))
            {
                return ConfigurationManager.AppSettings.Get("StratsysApiUrl") ?? DefaultApiBaseUrl;
            }

            return stratsysAuthentication.ApiBaseUrl;
        }

        public sealed override string BaseUrl
        {
            get
            {
                return m_apiBaseUrl;
            }
        }
    }
}