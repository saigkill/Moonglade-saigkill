using System.Net;
using System.Text.Json;

using Moonglade.Configuration;

using RestSharp;

namespace Moonglade.Data.ExternalAPI.IndexNow
{
    /// <summary>
    /// IndexNow Implementation
    /// Docs: https://www.indexnow.org/de_de/documentation
    /// </summary>
    public class IndexNow
    {
        public IBlogConfig _config;
        public readonly string bingAPI = "https://www.bing.com";
        public readonly string indexNowAPI = "https://api.indexnow.org";
        public readonly string seznamAPI = "https://search.seznam.cz";
        public readonly string yandexAPI = "https://yandex.com";


        public IndexNow(IBlogConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// Helper function to send an HTTP request through the requests.
        /// </summary>
        /// <returns>
        /// The response from the HTTP request.
        /// </returns>
        /// <exception cref="Exception">Throwed in case of not getting a HttpStatusCode.OK.</exception>
        public IRestResponse SendRequest(string link)
        {
            List<string> toPing = new List<string>();
            toPing.Add(bingAPI);
            toPing.Add(indexNowAPI);
            toPing.Add(seznamAPI);
            toPing.Add(yandexAPI);

            string endpoint = "/indexnow";

            string bodyContentType = "application/json";

            var host = new System.Uri(link).Host;

            string apiKey = _config.GeneralSettings.IndexNowAPIKey;

            foreach (var ping in toPing)
            {
                string finalurl = ping + endpoint;
                var method = Method.POST;
                RestClient client = new RestClient(finalurl);
                RestRequest request = new RestRequest(method);

                request.AddHeader("ContentType", bodyContentType);
                request.AddHeader("Host", ping);

                var bodyprep = new
                {
                    host = ping,
                    key = apiKey,
                    keyLocation = host + "/" + apiKey + ".txt",
                    urlList = new
                    {
                        link
                    }
                };
                var body = JsonSerializer.Serialize(bodyprep);


                if (method == Method.POST || method == Method.PATCH)
                {
                    if (body != null)
                    {
                        request.AddJsonBody(body);
                    }
                }

                IRestResponse response = client.Execute(request);
                HttpStatusCode responseStatus = response.StatusCode;

                switch (responseStatus)
                {
                    case HttpStatusCode.OK:
                        return response;
                    case HttpStatusCode.NoContent:
                        return response;
                    case HttpStatusCode.Created:
                        return response;
                    default:
                        throw new Exception("Request failed. See logs.");
                }
            }

            return null;
        }
    }
}
