using CI.HttpClient;
using System.Net;
using SimpleJSON;
using System.Security.Cryptography.X509Certificates;

namespace AssemblyCSharp
{
	public class YammerClient
	{
		private string BASE_URI = "https://www.yammer.com/";
		private string BEARER_TOKEN = "6631141-Lyo0n4Z0xpqQCUpkUCpuA";

        private string GROUP = "api/v1/messages/in_group/";

        private HttpClient client;

		public YammerClient()
		{
			ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

			client = new HttpClient();
			//client.Certificates.Add(X509Certificate.CreateFromCertFile("/Assets/www.yammer.com.crt"));

			StringContent content = new StringContent ("{}");
			client.CustomHeaders.Add ("Authorization", "Bearer " + BEARER_TOKEN);
			client.Headers.Add (HttpRequestHeader.Accept, "application/json");
        }

        private void get (string url, System.Action<CI.HttpClient.HttpResponseMessage<string>> callback)
        {
            client.GetString(new System.Uri(BASE_URI + url), callback);
        }
        
        public void getMessages (int groupId, System.Action<SimpleJSON.JSONArray> callback)
        {
            string url = GROUP + groupId;
            this.get(url, (response) => {
                JSONNode data = JSON.Parse(response.Data);
                JSONArray messages = (JSONArray)data["messages"];
                callback(messages);
            });
        }
	}
}
