using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class YammerController : MonoBehaviour {
	private string INBOX_UNREAD = "api/v2/inboxes?include_thread_starter=true&threads_count=20&messages_count=2&followed_threads=true&thread_read_state=UNREAD&for_feed=inboxUnread&fetch_type=initial";
    private string GROUP = "api/v2/networks/6631141/feeds/group/11186532?include_thread_starter=true&threads_count=8&messages_count=2&for_feed=group&fetch_type=initial";
    
    // Use this for initialization
    void Start () {
		var request = new YammerRequest (RestSharp.Method.POST, GROUP);
	}

	// Update is called once per frame
	void Update () {

	}
}
