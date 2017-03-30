using UnityEngine;
using CI.HttpClient;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using SimpleJSON;

namespace AssemblyCSharp
{
	public class YammerRequest
	{
		private string BASE_URI = "https://www.yammer.com/";
		private string BEARER_TOKEN = "6631141-Lyo0n4Z0xpqQCUpkUCpuA";

		public YammerRequest (string url)
		{
			ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

			HttpClient client = new HttpClient();
			//client.Certificates.Add(X509Certificate.CreateFromCertFile("/Assets/www.yammer.com.crt"));

			StringContent content = new StringContent ("{}");
			client.CustomHeaders.Add ("Authorization", "Bearer " + BEARER_TOKEN);
			client.Headers.Add (HttpRequestHeader.Accept, "application/json");

			client.GetString(new System.Uri(BASE_URI + url), (r) => {
                JSONNode data = JSON.Parse(r.Data);
                JSONArray messages = (JSONArray) data["messages"];
                Debug.Log(messages);
                foreach (JSONNode message in messages)
                {

                    Debug.Log(message["id"]);
                    Debug.Log(message["body"][0]);
                }
            });
        }
	}
}
