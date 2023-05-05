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
	public class IndexNowClient : IIndexNowClient
	{
		private IBlogConfig _config;
		private readonly string[] _toPing = new[] { "https://www.bing.com", "https://api.indexnow.org", "https://search.seznam.cz", "https://yandex.com" };

		public IndexNowClient(IBlogConfig config)
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
		public async Task<HttpStatusCode> SendRequestAsync(string urlToSubmit, string? body = "")
		{
			var bodyContentType = "application/json";
			var endpoint = "/indexnow";
			var host = new Uri(urlToSubmit).Host;
			var apiKey = _config.GeneralSettings.IndexNowAPIKey;

			foreach (var ping in _toPing)
			{
				var source = new CancellationTokenSource();
				var token = source.Token;

				var client = new RestClient(ping);
				var request = new RestRequest(endpoint, Method.Post);

				request.AddHeader("ContentType", bodyContentType);
				request.AddHeader("Host", ping);

				var bodyprep = new
				{
					host = host,
					key = apiKey,
					keyLocation = host + "/" + apiKey + ".txt",
					urlList = new
					{
						urlToSubmit
					}
				};
				var bodystring = JsonSerializer.Serialize(bodyprep);

				request.AddStringBody(bodystring, ContentType.Json);

				try
				{
					var response = await client.ExecutePostAsync(request, token);
					return response.StatusCode;
				}
				catch
				{
					throw new Exception("Request failed. See logs.");
				}
			}
			return HttpStatusCode.BadRequest;
		}
	}
}
