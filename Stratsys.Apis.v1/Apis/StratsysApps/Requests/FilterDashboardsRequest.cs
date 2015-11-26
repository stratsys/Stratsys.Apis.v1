using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.StratsysApps;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.StratsysApps.Requests
{
    public class FilterDashboardsRequest : StratsysClientRequest<IList<DashboardDto>>
    {
        private readonly string m_userId;

        public FilterDashboardsRequest(IClientService service, string userId, bool? onlyStartpage)
            : base(service)
        {
            m_userId = userId;
            if (onlyStartpage.HasValue)
            {
                RequestParameters.Add("onlyStartpage", onlyStartpage.ToString());
            }
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }

        public override string RestPath
        {
            get { return string.Format("users/{0}/filter", m_userId); }
        }
    }
}