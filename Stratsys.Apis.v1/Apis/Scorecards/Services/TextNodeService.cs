using Stratsys.Apis.v1.Apis.Scorecards.Resources;

namespace Stratsys.Apis.v1.Apis.Scorecards.Services
{
    public class TextNodeService : StratsysClientService
    {
        public TextNodeService(string clientId, string clientSecret)
            : base(clientId, clientSecret)
        {
            TextNodes = new TextNodeResource(this);
        }

        public override string Controller
        {
            get { return "textnodes"; }
        }

        public TextNodeResource TextNodes { get; private set; }
    }
}