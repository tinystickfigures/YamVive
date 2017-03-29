using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using UnityEngine;

public class YammerController : MonoBehaviour {

	private string BASE_URI = "https://www.yammer.com/";
	private string INBOX_UNREAD = "api/v2/inboxes?include_thread_starter=true&threads_count=20&messages_count=2&followed_threads=true&thread_read_state=UNREAD&for_feed=inboxUnread&fetch_type=initial";
	private string BEARER_TOKEN = "6631141-Lyo0n4Z0xpqQCUpkUCpuA";

	// Use this for initialization
	void Start () {
		var client = new HttpClient ();
		client.BaseAddress = new Uri (BASE_URI);
		client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BEARER_TOKEN);
	}

	// Update is called once per frame
	void Update () {

	}
}
