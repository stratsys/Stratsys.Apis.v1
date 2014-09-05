using System.Configuration;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis
{
    public abstract class StratsysClientService : BaseClientService
    {
        private readonly string m_apiUrl = ConfigurationManager.AppSettings.Get("StratsysApiUrl") ?? "https://www.stratsys.se/api/v1/";
        protected StratsysClientService(StratsysAuthentication authentication)
        {
            Authentication = authentication.AuthenticationHeaderValue;
        }

        public sealed override string BaseUrl
        {
            get
            {
                return m_apiUrl;
            }
        }
    }

    public class GenericService: StratsysClientService
    {
        private readonly string m_controller;

        public GenericService(StratsysAuthentication authentication, string controller) : base(authentication)
        {
            m_controller = controller;
        }

        public override string Controller
        {
            get { return m_controller; }
        }
    }


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

        public static Path Scorecard(string id)
        {
            return new Path("scorecards/" + id + "/");
        }

        public static Path ScorecardColumn(string id)
        {
            return new Path("scorecardcolumns/" + id + "/");
        }

        public Path Id(string id)
        {
            m_path += "/" + id + "/";
            return this;
        }

        public Path Resource(string name)
        {
            m_path += name;
            return this;
        }

        public Path Department(string id)
        {
            m_path += "departments/" + id + "/";
            return this;
        }

        public Path Node(string id)
        {
            m_path += "nodes/" + id + "/";
            return this;
        }

    }
}