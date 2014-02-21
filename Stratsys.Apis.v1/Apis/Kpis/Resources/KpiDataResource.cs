using System;
using Stratsys.Apis.v1.Apis.Kpis.Requests;
using Stratsys.Apis.v1.Dtos.Kpis;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Kpis.Resources
{
    public class KpiDataResource
    {
        private readonly IClientService m_clientService;

        public KpiDataResource(IClientService clientService)
        {
            m_clientService = clientService;
        }

        public SaveOrUpdateKpiDataRequest SaveOrUpdate(KpiDataDto kpiData)
        {
            return new SaveOrUpdateKpiDataRequest(m_clientService, kpiData);
        }

        public FilterKpiDataRequest Filter(
            string kpiId,
            string departmentId = null,
            string kpiColumnId = null,
            string kpiColumnName = null,
            int? kpiColumnIndex = null,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            return new FilterKpiDataRequest(m_clientService, kpiId, departmentId, kpiColumnId, kpiColumnName, kpiColumnIndex, startDate, endDate);
        }
    }
}