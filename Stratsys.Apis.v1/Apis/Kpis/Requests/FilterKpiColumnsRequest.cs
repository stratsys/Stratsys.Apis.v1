using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Kpis;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Kpis.Requests
{
    public class FilterKpiColumnsRequest : StratsysClientRequest<IList<KpiColumnDto>>
    {
        private readonly string m_kpiId;

        public FilterKpiColumnsRequest(IClientService clientService,
            string kpiId, string departmentId, string name)
            : base(clientService)
        {
            m_kpiId = kpiId;
            RequestParameters.Add("departmentId", departmentId);
            RequestParameters.Add("name", name);
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