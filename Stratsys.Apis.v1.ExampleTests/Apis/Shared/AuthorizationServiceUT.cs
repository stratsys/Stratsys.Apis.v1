using System.Net;
using NUnit.Framework;
using Stratsys.Apis.v1.Apis;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Shared
{
    public class AuthorizationServiceUT : BaseTest
    {
        [Test]
        public void When_valid_clientId_and_clientSecret_Should_have_access()
        {
            var stratsysApiMetadata = Api.Authorizations.CheckAccess().Fetch();
            Assert.That(stratsysApiMetadata.Result, Is.EqualTo("Ok"));
        }

        [Test]
        public void When_invalid_clientId_and_clientSecret_Should_not_access()
        {
            var authorizations = new StratsysApi(new ServiceAccountBasicAuthentication(ClientId, "invalidSecret")).Authorizations;
            var httpResponseMessage = authorizations.CheckAccess().GetHttpResponse();
            Assert.That(httpResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }

        [TestCase("john.principal@rektor.com", "Dalhemsskolan")]
        public void ModuleAuthorizations_Rektor(string userId, string departmentName)
        {
            var authorizations = Api.Authorizations.GetModuleAuthorizations(userId).Result;

            var rektorAuthorizationDto = authorizations.Rektor;

            Assert.True(rektorAuthorizationDto.IsAuthorized);
            Assert.That(rektorAuthorizationDto.AuthorizedDepartments.Count, Is.EqualTo(2));
            Assert.That(rektorAuthorizationDto.AuthorizedDepartments[0].Name, Is.EqualTo("Dalhemsskolan"));

            Assert.False(authorizations.Meetings.IsAuthorized);
        }
    }
}