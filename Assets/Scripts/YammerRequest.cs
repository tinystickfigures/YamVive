using RestSharp;
using UnityEngine;

namespace AssemblyCSharp
{
	public class YammerRequest
	{
		private string BASE_URI = "https://www.yammer.com/";
		private string BEARER_TOKEN = "6631141-Lyo0n4Z0xpqQCUpkUCpuA";

		public YammerRequest (Method method, string url)
		{
            var client = new RestClient();
            client.BaseUrl = BASE_URI;
            
            var request = new RestRequest();
            request.Method = method;
            request.Resource = url;
            request.AddHeader("Authorization", "Bearer " + BEARER_TOKEN);

            client.ExecuteAsync(request, (response) =>
            {
                Debug.Log(response.Content);
            });
        }
	}
}
