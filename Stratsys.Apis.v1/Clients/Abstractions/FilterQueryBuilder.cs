using System.Collections.Generic;
using Stratsys.Core.Apis.Requests;

namespace Stratsys.Apis.v1.Clients.Abstractions
{
    public class FilterQueryBuilder
    {
        private readonly RequestUriBuilder m_requestUriBuilder;

        public FilterQueryBuilder()
        {
            m_requestUriBuilder = new RequestUriBuilder
            {
                QueryParameters = new Dictionary<string, string>(),
                RestUriPath = "/filter"
            };
        }

        public FilterQueryBuilder Add(string name, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                m_requestUriBuilder.QueryParameters[name] = value;
            }
            return this;
        }

        public FilterQueryBuilder Add(string name, int value)
        {
            return Add(name, "" + value);
        }

        public FilterQueryBuilder AddId(string value)
        {
            return Add("id", value);
        }

        public FilterQueryBuilder AddName(string value)
        {
            return Add("name", value);
        }

        public string Build()
        {
            return m_requestUriBuilder.Build();
        }
    }
}