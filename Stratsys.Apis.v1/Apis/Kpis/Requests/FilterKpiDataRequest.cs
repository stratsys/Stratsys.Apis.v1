using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Kpis;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Kpis.Requests
{
    public class FilterKpiDataRequest : StratsysClientRequest<IList<KpiDataDto>>
    {
        private readonly string m_kpiId;

        public FilterKpiDataRequest(
            IClientService clientService,
            string kpiId,
            string departmentId,
            string kpiColumnId,
            string startDate,
            string endDate
            )
            : base(clientService)
        {
            m_kpiId = kpiId;
            RequestParameters.Add("departmentId", departmentId);
            RequestParameters.Add("kpiColumnId", kpiColumnId);
            RequestParameters.Add("startDate", startDate);
            RequestParameters.Add("endDate", endDate);
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }

        public override string RestPath
        {
            get { return m_kpiId + "/filter"; }
        }
    }
}