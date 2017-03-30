﻿using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(PointerListener))]
public class Mailbox : MonoBehaviour
{
    List<YammerMessage> _yammerMessages;

    public MessageBox _messagePrefab;

    List<MessageBox> _messages = new List<MessageBox>();

    public float MessageHeight;
    public float MessageSpacing;

    bool _active;

	// Use this for initialization
	void Start ()
    {
        var yammerController = new YammerController();
        yammerController.fetchMessages((messages) =>
        {
            _yammerMessages = messages;
            ShowMessages(messages);
        });
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
            message.Message = msg.body;
            message.Name = getSenderName(msg.senderId);
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
                Destroy(message.gameObject);
            }
        }
    }
}
