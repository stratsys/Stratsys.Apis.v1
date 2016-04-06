namespace Stratsys.Apis.v1.Apis
{
    public class Path
    {
        private string m_path = "";

        private Path(string path)
        {
            m_path = path;
        }

        public string Build()
        {
            return m_path;
        }

        public string Nodes
        {
            get { return m_path + "nodes"; }
        }

        public string Descriptionfields
        {
            get { return m_path + "descriptionfields"; }
        }

        public string Keywords
        {
            get { return m_path + "keywords"; }
        }

        public string ResponsibilityRoles
        {
            get { return m_path + "responsibilityroles"; }
        }

        public string ExternalPages
        {
            get { return m_path + "externalpages"; }
        }

        public static Path Scorecard(string id)
        {
            return new Path("scorecards/" + id + "/");
        }

        public static Path ScorecardColumn(string id)
        {
            return new Path("scorecardcolumns/" + id + "/");
        }

        public static Path Parent(string path)
        {
            return new Path(path);
        }

        public Path Id(string id)
        {
            return new Path(m_path + "/" + id + "/");
        }

        public Path Resource(string name)
        {
            return new Path(m_path + name);
        }

        public Path Department(string id)
        {
            return new Path(m_path + "departments/" + id + "/");
        }

        public Path Node(string id)
        {
            return new Path(m_path + "nodes/" + id + "/");
        }

    }
}