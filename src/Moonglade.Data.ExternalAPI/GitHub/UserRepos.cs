using System.Net;

using Moonglade.Configuration;

using RestSharp;

namespace Moonglade.Data.ExternalAPI.GitHub
{
    public class UserRepos
    {
        public IBlogConfig _config;

        public UserRepos(IBlogConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// Helper function to send an HTTP request through the requests.
        /// </summary>
        /// <returns>
        /// The response from the HTTP request.
        /// </returns>
        /// <param name="method">HTTP request method (POST, GET, PUT, DELETE, etc.)</param>
        /// <param name="endpoint">Endpoint for the request.</param>
        /// <param name="bodyContentType">Content type for the body parameter (application/json, etc.)</param>
        /// <param name="body">Payload for the request (if it applies).</param>
        /// <exception cref="Exception">Throwed in case of not getting a HttpStatusCode.OK.</exception>
        public IRestResponse SendRequest(Method method, string endpoint, string body = "")
        {
            string baseUrl = $"https://api.github.com";
            string finalurl = baseUrl + endpoint;
            string bodyContentType = "application/vnd.github+json";

            RestClient client = new RestClient(finalurl);
            RestRequest request = new RestRequest(method);

            request.AddHeader("Accept", bodyContentType);
            request.AddHeader("Authorization", "Bearer" + _config.GeneralSettings.GithubPAT);
            request.AddHeader("X-GitHub-Api-Version", "2022-11-28");

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
    }
}