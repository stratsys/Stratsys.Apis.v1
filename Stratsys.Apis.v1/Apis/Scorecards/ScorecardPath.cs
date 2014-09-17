using Stratsys.Apis.v1.Apis.Scorecards.Requests;
using Stratsys.Apis.v1.Apis.Scorecards.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards
{
    public class ScorecardsPath
    {
        private readonly StratsysAuthentication m_authentication;
        private readonly string m_id;
        private readonly ScorecardColumnService m_scorecardColumnService;

        public ScorecardsPath(StratsysAuthentication authentication, string id)
        {
            m_authentication = authentication;
            m_id = id;
            m_scorecardColumnService = new ScorecardColumnService(authentication);
        }

        public ScorecardsDepartmentsPath Department(string id)
        {
            return new ScorecardsDepartmentsPath(m_authentication, Path.Scorecard(m_id).Department(id));
        }

        public FilterScorecardColumnsRequest Columns
        {
            get { return m_scorecardColumnService.ScorecardColumns.Filter(m_id); }
        }
    }
}