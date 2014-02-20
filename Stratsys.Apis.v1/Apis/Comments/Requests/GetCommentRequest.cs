using Stratsys.Apis.v1.Dtos.Comments;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Comments.Requests
{
    public class GetCommentRequest : StratsysClientRequest<CommentDto>
    {
        private readonly string m_id;

        public GetCommentRequest(IClientService service, string id) : base(service)
        {
            m_id = id;
        }

        public override string RestPath
        {
            get { return m_id; }
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }
    }
}