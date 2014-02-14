using System.Net;
using NUnit.Framework;
using Stratsys.Apis.v1.Apis.Shared.Resources;
using Stratsys.Apis.v1.Apis.Shared.Services;
using Stratsys.Apis.v1.Tests;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Shared
{
    public class AuthorizationServiceUT : BaseTest
    {
        [Test]
        public void When_valid_clientId_and_clientSecret_Should_have_access()
        {
            var stratsysApiMetadata = Authorizations.CheckAccess().Fetch();
            Assert.That(stratsysApiMetadata.Result, Is.EqualTo("Ok"));
        }

        [Test]
        public void When_invalid_clientId_and_clientSecret_Should_not_access()
        {
            var authorizations = new AuthorizationService(ClientId, "invalidSecret").Authorizations;
            var httpResponseMessage = authorizations.CheckAccess().GetHttpResponse();
            Assert.That(httpResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }

        private AuthorizationResource Authorizations
        {
            get
            {
                return new AuthorizationService(ClientId, ClientSecret).Authorizations;
            }
        }
    }
}