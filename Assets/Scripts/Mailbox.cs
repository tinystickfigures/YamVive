using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PointerListener))]
public class Mailbox : MonoBehaviour
{
    List<string> _messageStrings = new List<string>() { "This is a Yammer message", "Another Yammer message", "Yammer is the best" };

    public Message _messagePrefab;

    List<Message> _messages = new List<Message>();

    public float MessageHeight;
    public float MessageSpacing;

    bool _active;

	// Use this for initialization
	void Start ()
    {
        var pointerResponder = GetComponent<PointerListener>();
        pointerResponder.AddOnClickEvent(OnClick);
    }
	
    void OnClick()
    {
        if (_active)
        {
            HideMessages();
            _active = false;
        }
        else
        {
            _messages.Clear();
            ShowMessages(_messageStrings);
            _active = true;
        }
    }

    void ShowMessages(List<string> strings)
    {
        _messages.Clear();
        var position = gameObject.transform.position + new Vector3(0, MessageHeight, -1 * (strings.Count - 1) * MessageSpacing/2f);
        foreach (var msg in strings)
        {
            var message = Instantiate(_messagePrefab, gameObject.transform) as Message;
            message.Text = msg;
            message.transform.position = position;
            position += new Vector3(0, 0, MessageSpacing);
            _messages.Add(message);
        }
    }

    void HideMessages()
    {
        foreach (var message in _messages)
        {
            Destroy(message.gameObject);
        }
    }
}
