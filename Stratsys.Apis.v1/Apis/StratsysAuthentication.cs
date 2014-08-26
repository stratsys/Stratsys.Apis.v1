using System.Net.Http.Headers;

namespace Stratsys.Apis.v1.Apis
{
    public abstract class StratsysAuthentication
    {
        public abstract AuthenticationHeaderValue AuthenticationHeaderValue { get; }
    }
}