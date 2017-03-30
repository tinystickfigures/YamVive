using UnityEngine;
using AssemblyCSharp;
using SimpleJSON;
using System.Collections.Generic;

public class YammerController : MonoBehaviour {

    private YammerClient yammerClient;

    // Use this for initialization
    void Start () {
        yammerClient = new YammerClient();
	}

    public void fetchMessages (System.Action<System.Collections.Generic.List<YammerMessage>> callback)
    {
        yammerClient = new YammerClient();
        yammerClient.getMessages(11186532, (messages) =>
        {
            List<YammerMessage> yammerMessages = new List<YammerMessage>();
            foreach (JSONNode message in messages)
            {
                int id = message["id"];
                int senderId = message["sender_id"];
                string body = message["body"]["parsed"];
                YammerMessage yammerMessage = new YammerMessage(id, senderId, body);
                yammerMessages.Add(yammerMessage);
            }
            callback(yammerMessages);
        });
    }
}
