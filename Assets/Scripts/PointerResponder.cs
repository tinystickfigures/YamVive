using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PointerResponder : MonoBehaviour {

    // TODO: Remember how to use the C# event system instead of doing it myself lol
    List<Action> _enterEvents = new List<Action>();
    List<Action> _clickEvents = new List<Action>();
    List<Action> _exitEvents = new List<Action>();

    public void AddOnEnterEvent(Action action)
    {
        _enterEvents.Add(action);
    }

    public void AddOnClickEvent(Action action)
    {
        _clickEvents.Add(action);
    }

    public void AddOnExitEvent(Action action)
    {
        _exitEvents.Add(action);
    }

    public void OnEnter()
    {
        _enterEvents.ForEach(e => e.Invoke());
    }

    public void OnClick()
    {
        _clickEvents.ForEach(e => e.Invoke());
    }

    public void OnExit()
    {
        _exitEvents.ForEach(e => e.Invoke());
    }
}
