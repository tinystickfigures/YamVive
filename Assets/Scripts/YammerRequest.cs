using UnityEngine;
using CI.HttpClient;
using System.Net;
using System.Security.Cryptography.X509Certificates;

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
				var data = r.Data;
				Debug.Log(data);
			});
        }
	}
}
