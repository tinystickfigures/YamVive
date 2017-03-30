using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PointerListener))]
public class Mailbox : MonoBehaviour
{
    List<YammerMessage> _yammerMessages = new List<YammerMessage>()
    {
        new YammerMessage("Harry", "Help, my potions homework keeps exploding"),
        new YammerMessage("Hermione", "Let's meet up for study group"),
        new YammerMessage("Draco", "DAE think Harry smells bad??")
    };

    public MessageBox _messagePrefab;

    List<MessageBox> _messages = new List<MessageBox>();

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
            ShowMessages(_yammerMessages);
            _active = true;
        }
    }

    void ShowMessages(List<YammerMessage> yammerMessages)
    {
        _messages.Clear();
        var position = gameObject.transform.position + new Vector3(0, MessageHeight, -1 * (yammerMessages.Count - 1) * MessageSpacing/2f);
        foreach (var msg in yammerMessages)
        {
            var message = Instantiate(_messagePrefab, gameObject.transform) as MessageBox;
            message.Message = msg.Message;
            message.Name = msg.Name;
            message.transform.position = position;
            position += new Vector3(0, 0, MessageSpacing);
            _messages.Add(message);
        }
    }

    void HideMessages()
    {
        foreach (var message in _messages)
        {
            if (message != null)
            {
                Destroy(message.gameObject);
            }
        }
    }
}
