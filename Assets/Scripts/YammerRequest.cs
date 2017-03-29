using System;
using System.Net;
using System.Net.HttpWebRequest;

namespace AssemblyCSharp
{
	public class YammerRequest
	{
		private string BASE_URI = "https://www.yammer.com/";
		private string BEARER_TOKEN = "6631141-Lyo0n4Z0xpqQCUpkUCpuA";
		private HttpWebRequest request;

		public YammerRequest (string method, string url)
		{
			request = (HttpWebRequest)WebRequest.Create(BASE_URI + url);
			request.Method = method;
			request.Accept = "application/json";
			request.Headers.Add ("Authorization", "Bearer " + BEARER_TOKEN);
		}
		public HttpWebResponse getResponse ()
		{
			return (HttpWebResponse) request.GetResponse ();
		}
	}
}

