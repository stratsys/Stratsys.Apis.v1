using Stratsys.Apis.v1.Apis.Scorecards.Resources;

namespace Stratsys.Apis.v1.Apis.Scorecards.Services
{
    public class NodeService : StratsysClientService
    {
        public NodeService(string clientId, string clientSecret)
            : base(clientId, clientSecret)
        {
            Nodes = new NodeResource(this);
        }

        public override string Controller
        {
            get { return "nodes"; }
        }

        public NodeResource Nodes { get; private set; }
    }
}