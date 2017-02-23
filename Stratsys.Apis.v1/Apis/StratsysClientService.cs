using System.Configuration;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis
{
    public abstract class StratsysClientService : BaseClientService
    {
        private readonly string m_apiUrl = ConfigurationManager.AppSettings.Get("StratsysApiUrl") ?? "https://www.stratsys.se/api/v1/";
        protected StratsysClientService(StratsysAuthentication stratsysAuthentication)
        {
            Authentication = stratsysAuthentication.AuthenticationHeaderValue;
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