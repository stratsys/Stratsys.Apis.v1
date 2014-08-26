using Stratsys.Apis.v1.Apis.Scorecards.Resources;

namespace Stratsys.Apis.v1.Apis.Scorecards.Services
{
    public class KeywordGroupService : StratsysClientService
    {
        public KeywordGroupService(StratsysAuthentication authentication)
            : base(authentication)
        {
            Keywordgroups = new KeywordGroupResource(this);
        }

        public override string Controller
        {
            get { return "keywordgroups"; }
        }

        public KeywordGroupResource Keywordgroups { get; private set; }

    }
}
