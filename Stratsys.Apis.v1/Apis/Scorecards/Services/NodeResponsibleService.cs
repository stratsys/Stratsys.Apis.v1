using Stratsys.Apis.v1.Apis.Scorecards.Resources;

namespace Stratsys.Apis.v1.Apis.Scorecards.Services
{
    public class NodeResponsibleService : StratsysClientService
    {
        public NodeResponsibleService(StratsysAuthentication authentication)
            : base(authentication)
        {
            NodeResponsibles = new NodeResponsibleResource(this);
        }

        public override string Controller
        {
            get { return "noderesponsibles"; }
        }

        public NodeResponsibleResource NodeResponsibles { get; private set; }

    }
}