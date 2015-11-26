using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.StratsysApps;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.StratsysApps.Requests
{
    public class GetUserReportListItemsRequest : StratsysClientRequest<IList<UserReportListItemDto>>
    {
        private readonly string m_userId;
        private readonly string m_reportListId;

        public GetUserReportListItemsRequest(IClientService clientService,
            string reportListId,
            string userId,
            bool? showAll)
            : base(clientService)
        {
            m_userId = userId;
            m_reportListId = reportListId;
            if (showAll.HasValue)
            {
                RequestParameters.Add("showAll", showAll.Value + "");
            }
        }

        public override string RestPath
        {
            get { return m_reportListId + "/users/" + m_userId; }
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }
    }
}