using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using Stratsys.Apis.v1.Apis;
using Stratsys.Core.Apis.Requests;

namespace Stratsys.Apis.v1.Clients.Abstractions
{
    public class StratsysResource<T>
    {
        private readonly string m_apiUrl = ConfigurationManager.AppSettings.Get("StratsysApiUrl") ?? "https://www.stratsys.se/api/v1/";

        private readonly string m_controller;
        private readonly HttpClient m_httpClient;

        public StratsysResource(string controller, StratsysAuthentication authentication)
        {
            m_controller = controller;
            m_httpClient = new HttpClient { BaseAddress = new Uri(m_apiUrl) };
            m_httpClient.DefaultRequestHeaders.Authorization = authentication.AuthenticationHeaderValue;
            m_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public T Get(string id)
        {
            var builder = new RequestUriBuilder
            {
                RestUriPath = "/" + id,
            };
            return m_httpClient.GetAsync<T>(m_controller + builder.Build()).Result;
        }

        public T Get(string id, string fields)
        {
            var builder = new RequestUriBuilder
            {
                RestUriPath = "/" + id,
                QueryParameters = new Dictionary<string, string>()
            };
            builder.QueryParameters["fields"] = fields;
            return m_httpClient.GetAsync<T>(m_controller + builder.Build()).Result;
        }

        public IList<T> List(string name = null)
        {
            var builder = new RequestUriBuilder();
            if (name != null)
            {
                builder.QueryParameters.Add("name", name);
            }
            var path = m_controller + builder.Build();
            return m_httpClient.GetAsync<IList<T>>(path).Result;
        }

        public IList<T> Filter(string name = null)
        {
            var builder = new RequestUriBuilder
            {
                RestUriPath = "/filter",
                QueryParameters = new Dictionary<string, string>()
            };
            if (name != null)
            {
                builder.QueryParameters.Add("name", name);
            }
            return m_httpClient.GetAsync<IList<T>>(m_controller + builder.Build()).Result;
        }

        public IList<T> Filter(FilterQueryBuilder builder)
        {
            return m_httpClient.GetAsync<IList<T>>(m_controller + builder.Build()).Result;
        }

        public T Put(T value)
        {
            return m_httpClient.PutAsync<T, T>(m_controller, value).Result;
        }

        public T Put(string id)
        {
            return m_httpClient.PutAsync<string, T>(m_controller + "/" + id, null).Result;
        }

        public string Post(T value)
        {
            return m_httpClient.PostAsync<T, string>(m_controller, value).Result;
        }

        public bool Delete(string id)
        {
            var builder = new RequestUriBuilder
            {
                RestUriPath = "/" + id
            };
            return m_httpClient.DeleteAsync<string, bool>(m_controller + builder.Build()).Result;
        }
    }
}