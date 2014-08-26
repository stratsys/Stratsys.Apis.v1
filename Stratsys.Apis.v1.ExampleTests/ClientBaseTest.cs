using Stratsys.Apis.v1.Apis;
using Stratsys.Apis.v1.Clients;

namespace Stratsys.Apis.v1.ExampleTests
{
    public abstract class ClientBaseTest : BaseTest
    {
        protected StratsysClient Client
        {
            get { return new StratsysClient(new ServiceAccountBasicAuthentication(ClientId,ClientSecret));}
        }
    }
}