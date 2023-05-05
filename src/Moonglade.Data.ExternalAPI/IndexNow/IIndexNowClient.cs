using System.Net;
using RestSharp;

namespace Moonglade.Data.ExternalAPI.IndexNow;

public interface IIndexNowClient
{
	Task<HttpStatusCode> SendRequestAsync(string urlToSubmit, string? body = "");
}
