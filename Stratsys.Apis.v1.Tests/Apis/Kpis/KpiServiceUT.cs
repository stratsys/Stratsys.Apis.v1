using NUnit.Framework;
using Stratsys.Apis.v1.Apis.Kpis;
using Stratsys.Apis.v1.Apis.Kpis.Resources;
using Stratsys.Apis.v1.Apis.Kpis.Services;
using Stratsys.Apis.v1.Tests;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Kpis
{
    public class KpiServiceUT :BaseTest
    {
        [TestCase("Arbetskraftens storlek 16-64 år", 2)]
        public void When_filtering_on_kpis_by_name_Should_get_filtered_kpis(string nameFilter, int expectedNumberOfKpis)
        {
            var kpis = Kpis.Filter(name: nameFilter).Fetch().Result;
            Assert.That(kpis.Count, Is.EqualTo(expectedNumberOfKpis));
        }

        [TestCase("16365", 2)]
        public void When_filtering_on_kpis_by_id_Should_get_filtered_kpis(string idFilter, int expectedNumberOfKpis)
        {
            var kpis = Kpis.Filter(idFilter).Fetch().Result;
            Assert.That(kpis.Count, Is.EqualTo(expectedNumberOfKpis));
        }

        [TestCase("1", 167)]
        public void When_filtering_on_kpis_by_departmentId_Should_get_filtered_kpis(string departmentFilter, int expectedNumberOfKpis)
        {
            var kpis = Kpis.Filter(departmentId: departmentFilter).Fetch().Result;
            Assert.That(kpis.Count, Is.EqualTo(expectedNumberOfKpis));
        }

        [TestCase("1", 597)]
        public void When_filtering_on_kpis_by_scorecardId_Should_get_filtered_kpis(string scorecardFilter, int expectedNumberOfKpis)
        {
            var kpis = Kpis.Filter(scorecardId: scorecardFilter).Fetch().Result;
            Assert.That(kpis.Count, Is.EqualTo(expectedNumberOfKpis));
        }

        [TestCase("16365", "1", "Arbetskraftens storlek 16-64 år", "1", 5)]
        public void When_filtering_on_kpis_by_id_and_department_Should_get_unique_kpi(
            string idFilter, string departmentFilter, 
            string expectedName, string expectedPeriodicityId, int expectedNumberOfKpiColumns)
        {
            var kpis = Kpis.Filter(idFilter, departmentFilter).Fetch().Result;
            Assert.That(kpis.Count, Is.EqualTo(1));
            var kpi = kpis[0];
            Assert.That(kpi.Id, Is.EqualTo(idFilter));
            Assert.That(kpi.DepartmentId, Is.EqualTo(departmentFilter));
            Assert.That(kpi.Name, Is.EqualTo(expectedName));
            Assert.That(kpi.PeriodicityId, Is.EqualTo(expectedPeriodicityId));
            Assert.That(kpi.KpiColumnIds.Count, Is.EqualTo(expectedNumberOfKpiColumns));
        }

        private KpiResource Kpis
        {
            get
            {
                return new KpiService(ClientId, ClientSecret).Kpis;
            }
        }
    }
}