using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YammerMessage : MonoBehaviour
{
    public string Name;
    public string Message;

    public YammerMessage(string name, string message)
    {
        Name = name;
        Message = message;
    }
}
