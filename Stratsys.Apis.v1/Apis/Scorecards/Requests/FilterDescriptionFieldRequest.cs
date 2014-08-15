using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards.Requests
{
    public class FilterDescriptionFieldRequest : StratsysClientRequest<List<DescriptionFieldDto>>
    {
        public FilterDescriptionFieldRequest(
            IClientService service,
            string scorecardColumnId
            )
            : base(service)
        {
            RequestParameters.Add("scorecardColumnId", scorecardColumnId);
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }

        public override string RestPath
        {
            get { return "filter"; }
        }
    }
}