using System.Net.Http.Headers;

namespace Stratsys.Apis.v1.Apis
{
    public class OauthBearerAuthentication : StratsysAuthentication
    {
        private readonly string m_token;

        public OauthBearerAuthentication(string token)
        {
            m_token = token;
        }

        public OauthBearerAuthentication(string companyCode, string token)
        {
            m_token = companyCode + "_" + token;
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