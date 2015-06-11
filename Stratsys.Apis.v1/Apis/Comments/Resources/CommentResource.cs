using Stratsys.Apis.v1.Apis.Comments.Requests;
using Stratsys.Apis.v1.Dtos.Comments;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Comments.Resources
{
    public class CommentResource
    {
        private readonly IClientService m_clientService;

        public CommentResource(IClientService clientService)
        {
            m_clientService = clientService;
        }

        public FilterCommentsRequest Filter(string nodeId, string departmentId = null)
        {
            return new FilterCommentsRequest(m_clientService, nodeId, departmentId);
        }

        public AddCommentRequest AddComment(AddCommentDto comment)
        {
            return new AddCommentRequest(m_clientService, comment);
        }

        public GetCommentRequest Get(string id)
        {
            return new GetCommentRequest(m_clientService, id);
        }

        public UpdateCommentRequest Update(UpdateCommentDto comment)
        {
            return new UpdateCommentRequest(m_clientService, comment);
        }

        public DeleteRequest<bool> Delete(string id)
        {
            return new DeleteRequest<bool>(m_clientService, id);
        }
    }
}