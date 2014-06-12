using Stratsys.Apis.v1.Apis.Comments.Resources;

namespace Stratsys.Apis.v1.Apis.Comments.Services
{
    public class CommentService : StratsysClientService
    {
        public CommentService(StratsysAuthentication authentication) : base(authentication)
        {
            Comments = new CommentResource(this);
        }

        public override string Controller
        {
            get { return "comments"; }
        }

        public CommentResource Comments { get; private set; }
    }
}