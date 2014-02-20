using Stratsys.Apis.v1.Dtos.Comments;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Comments.Requests
{
    public class UpdateCommentRequest : StratsysClientRequest<string>
    {
        private readonly UpdateCommentDto m_comment;

        public UpdateCommentRequest(IClientService service, UpdateCommentDto comment)
            : base(service)
        {
            m_comment = comment;
        }

        public override object Body
        {
            get
            {
                return m_comment;
            }
        }

        public override string HttpMethod
        {
            get { return "PUT"; }
        }
    }
}