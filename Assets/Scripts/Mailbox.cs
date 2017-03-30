using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(PointerListener))]
public class Mailbox : MonoBehaviour
{

    public MessageBox _messagePrefab;

    List<MessageBox> _messages = new List<MessageBox>();

    public float MessageHeight;
    public float MessageSpacing;

    bool _active;

    YammerController _yammer;

	// Use this for initialization
	void Start ()
    {
        var pointerResponder = GetComponent<PointerListener>();
        pointerResponder.AddOnClickEvent(OnClick);
        _yammer = FindObjectOfType<YammerController>();
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
            _yammer.fetchMessages((messages) =>
            {
                ShowMessages(messages);
                _active = true;
            });
        }
    }

    void ShowMessages(List<YammerMessage> yammerMessages)
    {
        _messages.Clear();
        var position = gameObject.transform.position + new Vector3(0, MessageHeight, -1 * (yammerMessages.Count - 1) * MessageSpacing/2f);
        foreach (var msg in yammerMessages)
        {
            var message = Instantiate(_messagePrefab, gameObject.transform) as MessageBox;
            message.Message = msg.body;
            message.PopulateNameAndMugshot(msg.senderId);
            message.transform.position = position;
            position += new Vector3(0, 0, MessageSpacing);
            _messages.Add(message);
        }
    }

    private string getSenderName (int senderId)
    {
        // TODO
        Debug.Log("getting sender name for " + senderId);
        return "Dumbles";
    }

    void HideMessages()
    {
        foreach (var message in _messages)
        {
            if (message != null)
            {
                //Destroy(message.gameObject);
            }
        }
    }

    void OnDestroy()
    {
        Debug.Log("fdsgsafdg");
    }
}
