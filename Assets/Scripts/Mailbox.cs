using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PointerResponder))]
public class Mailbox : MonoBehaviour
{
    string[] _messageStrings = { "This is a Yammer message", "Another Yammer message", "Yammer is the best" };

    public Message _messagePrefab;

    List<Message> _messages;

    public float MessageHeight;
    public float MessageSpacing;

	// Use this for initialization
	void Start ()
    {
        var pointerResponder = GetComponent<PointerResponder>();
        pointerResponder.AddOnClickEvent(OnClick);
    }
	
    void OnClick()
    {
        var position = gameObject.transform.position;
        foreach (var msg in _messageStrings)
        {
            var message = Instantiate(_messagePrefab, gameObject.transform) as Message;
            message.Text = msg;
            //message.transform.position = 
        }
    }
}
