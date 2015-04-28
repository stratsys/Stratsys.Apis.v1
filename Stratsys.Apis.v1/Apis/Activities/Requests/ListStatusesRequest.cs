using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Activities;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Activities.Requests
{
    public class ListStatusesRequest : StratsysClientRequest<List<StatusDto>>
    {
        private readonly string m_scorecardColumnId;

        public ListStatusesRequest(IClientService service, string scorecardColumnId)
            : base(service)
        {
            m_scorecardColumnId = scorecardColumnId;
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }

        public override string RestPath
        {
            get { return string.Format("{0}/filter", m_scorecardColumnId); }
        }
    }
}