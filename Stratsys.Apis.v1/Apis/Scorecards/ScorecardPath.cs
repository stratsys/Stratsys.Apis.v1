namespace Stratsys.Apis.v1.Apis.Scorecards
{
    public class ScorecardsPath
    {
        private readonly StratsysAuthentication m_authentication;
        private readonly string m_id;

        public ScorecardsPath(StratsysAuthentication authentication, string id)
        {
            m_authentication = authentication;
            m_id = id;
        }

        public ScorecardsDepartmentsPath Department(string id)
        {
            return new ScorecardsDepartmentsPath(m_authentication, m_id, id);
        }
    }
}