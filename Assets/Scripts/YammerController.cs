using UnityEngine;
using AssemblyCSharp;
using SimpleJSON;

public class YammerController : MonoBehaviour {

    // Use this for initialization
    void Start () {
        var yammerClient = new YammerClient();
        yammerClient.getMessages(11186532, (messages) =>
        {
            Debug.Log(messages);
            foreach (JSONNode message in messages)
            {
                Debug.Log(message["id"]);
                Debug.Log(message["body"][0]);
            }
        });
	}
}
