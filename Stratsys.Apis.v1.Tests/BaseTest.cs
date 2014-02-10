﻿using System.Configuration;
using NUnit.Framework;

namespace Stratsys.Apis.v1.Tests
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected string ClientId = ConfigurationManager.AppSettings.Get("TestClientId");
        protected string ClientSecret = ConfigurationManager.AppSettings.Get("TestClientSecret"); //ask support for access to ApiPublicTests if wanted

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
        public virtual void SetUp()
        {
        }

        /// <summary>
        /// Functions that are performed just before each test method is called.
        /// </summary>
        protected virtual void SetUpBaseTest()
        {
        }
    }
}
