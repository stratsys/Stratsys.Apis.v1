using System.Collections.Generic;
using Stratsys.Apis.v1.Dtos.Comments;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Comments.Requests
{
    public class FilterCommentsRequest : StratsysClientRequest<IList<CommentDto>>
    {
        private readonly string m_nodeId;

        public FilterCommentsRequest(IClientService service, 
            string nodeId,
            string departmentId= null) : base(service)
        {
            m_nodeId = nodeId;
            RequestParameters.Add("departmentId", departmentId);
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }

        public override string RestPath
        {
            get { return string.Format("{0}/filter", m_nodeId); }
        }
    }
}