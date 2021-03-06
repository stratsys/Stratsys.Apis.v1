﻿using System.Configuration;
using NUnit.Framework;
using Stratsys.Apis.v1.Apis;

namespace Stratsys.Apis.v1.ExampleTests
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected readonly string ClientId = ConfigurationManager.AppSettings.Get("TestClientId");

        protected string ClientSecret = ConfigurationManager.AppSettings.Get("TestClientSecret"); //ask Stratsys support for access to database used in tests.

        private readonly string ClientToken = ConfigurationManager.AppSettings.Get("TestClientToken"); //ask Stratsys support for access to database used in tests.

        protected StratsysApi Api { get { return new StratsysApi(ServiceAuthentication); } }

        protected ServiceAccountBasicAuthentication ServiceAuthentication
        {
            get { return new ServiceAccountBasicAuthentication(ClientId, ClientSecret); }
        }

        protected OauthBearerAuthentication BearerAuthentication
        {
            get { return new OauthBearerAuthentication(ClientId, ClientToken); }
        }

        protected StratsysApi StratsysApi(StratsysAuthentication stratsysAuthentication)
        {
            return new StratsysApi(stratsysAuthentication);
        }

        [TestFixtureSetUp]
        public void SetUpFixtureBase_DoNotCall()
        {
            SetUpFixtureBaseTest();
            SetUpFixture();
        }

        /// <summary>
        /// Functions that are performed once prior to executing any of the tests in the fixture.
        /// </summary>
        protected virtual void SetUpFixtureBaseTest()
        {
        }

        /// <summary>
        /// Functions that are performed once prior to executing any of the tests in the fixture.
        /// </summary>
        public virtual void SetUpFixture()
        {
        }

        [SetUp]
        public void SetUpBase_DoNotCall()
        {
            SetUpBaseTest();
            SetUp();
        }

        /// <summary>
        /// Functions that are performed just before each test method is called.
        /// </summary>
        protected virtual void SetUp()
        {
        }

        /// <summary>
        /// Functions that are performed just before each test method is called.
        /// </summary>
        protected virtual void SetUpBaseTest()
        {
        }

        [TearDown]
        public void TearDownBase_DoNotCall()
        {
            TearDownBaseTest();
            TearDown();
        }

        protected virtual void TearDownBaseTest()
        {
        }

        protected virtual void TearDown()
        {
        }
    }

    public abstract class ExternalCodeApiTest : BaseTest
    {
        protected ExternalCodeApiTest()
        {
            ClientSecret = ConfigurationManager.AppSettings.Get("TestExternalCodeClientSecret"); //ask Stratsys support for access to database used in tests.
        }
    }
}
