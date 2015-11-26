using Stratsys.Apis.v1.Dtos.StratsysApps;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.StratsysApps.Requests
{
    public class GetUserReportingListRequest : StratsysClientRequest<UserReportingListDto>
    {
        private readonly string m_userId;
        private readonly string m_reportingListId;

        public GetUserReportingListRequest(IClientService clientService,
            string reportingListId,
            string userId,
            bool? showAll)
            : base(clientService)
        {
            m_userId = userId;
            m_reportingListId = reportingListId;
            if (showAll.HasValue)
            {
                RequestParameters.Add("showAll", showAll.Value + "");
            }
        }

        public override string RestPath
        {
            get { return m_reportingListId + "/users/" + m_userId; }
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }
    }
}