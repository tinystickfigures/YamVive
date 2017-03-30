using UnityEngine;

public class YammerMessage
{
    public int id;
    public int senderId;
    public string body;

    public YammerMessage(int _id, int _senderId, string _body)
    {
        id = _id;
        senderId = _senderId;
        body = _body;
    }
}
