using UnityEngine;
using AssemblyCSharp;

public class YammerController : MonoBehaviour {
	private string INBOX_UNREAD = "api/v2/inboxes?include_thread_starter=true&threads_count=20&messages_count=2&followed_threads=true&thread_read_state=UNREAD&for_feed=inboxUnread&fetch_type=initial";
	private string GROUP = "api/v1/messages/in_group/11186532";

    // Use this for initialization
    void Start () {
        Debug.Log("STARTTTT");
        var request = new YammerRequest (GROUP);
	}
}
