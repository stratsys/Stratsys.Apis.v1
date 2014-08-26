using Stratsys.Apis.v1.Apis.Scorecards.Resources;
using Stratsys.Apis.v1.Apis.Scorecards.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards
{
    public class ScorecardsDepartmentsPath
    {

        public ScorecardsDepartmentsPath(StratsysAuthentication authentication,
            string scorecardId, string departmentId)
        {
            var scorecardNodeService = new ScorecardNodeService(authentication, scorecardId,departmentId);
            Nodes = scorecardNodeService.Nodes;
        }

        public ScorecardNodeResource Nodes { get; private set; }

    }
}