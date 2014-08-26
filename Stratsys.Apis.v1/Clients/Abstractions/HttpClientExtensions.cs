using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using Stratsys.Apis.v1.Dtos;

namespace Stratsys.Apis.v1.Clients.Abstractions
{
    public static class HttpClientExtensions
    {
        public static StratsysApiMetadata<T> GetAsync<T>(this HttpClient httpClient, string path)
        {
            var message = httpClient.GetAsync(path).Result;
            CheckMessage<T>(message);
            var metadata = message.Content.ReadAsAsync<StratsysApiMetadata<T>>().Result;
            return metadata;
        }

        public static StratsysApiMetadata<TR> PutAsync<T, TR>(this HttpClient httpClient, string path, T value)
        {
            var message = httpClient.PutAsync(path, value, new JsonMediaTypeFormatter()).Result;
            CheckMessage<T>(message);
            var metadata = message.Content.ReadAsAsync<StratsysApiMetadata<TR>>().Result;
            return metadata;
        }

        public static StratsysApiMetadata<TR> PostAsync<T, TR>(this HttpClient httpClient, string path, T value)
        {
            var message = httpClient.PostAsync(path, value, new JsonMediaTypeFormatter()).Result;
            CheckMessage<T>(message);
            var metadata = message.Content.ReadAsAsync<StratsysApiMetadata<TR>>().Result;
            return metadata;
        }

        public static StratsysApiMetadata<TR> DeleteAsync<T, TR>(this HttpClient httpClient, string path)
        {
            var message = httpClient.DeleteAsync(path).Result;
            CheckMessage<T>(message);
            var metadata = message.Content.ReadAsAsync<StratsysApiMetadata<TR>>().Result;
            return metadata;
        }

        private static void CheckMessage<T>(HttpResponseMessage message)
        {
            if (!message.IsSuccessStatusCode)
            {
                if (message.StatusCode == HttpStatusCode.BadRequest)
                {
                    var stratsysApiMetadata = message.Content.ReadAsAsync<StratsysApiMetadata<T>>().Result;
                    throw new HttpRequestException(message.ReasonPhrase, new HttpRequestException(stratsysApiMetadata.Message));
                }
                if (message.StatusCode == HttpStatusCode.MethodNotAllowed)
                    throw new HttpRequestException(message.RequestMessage.Method.ToString(), new HttpRequestException(message.ReasonPhrase));

                throw new HttpRequestException(message.ReasonPhrase);
            }
        }
    }
}