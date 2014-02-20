using Stratsys.Apis.v1.Dtos.Comments;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Comments.Requests
{
    public class AddCommentRequest : StratsysClientRequest<string>
    {
        private readonly AddCommentDto m_comment;

        public AddCommentRequest(IClientService service, AddCommentDto comment) : base(service)
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
            get { return "POST"; }
        }
    }
}