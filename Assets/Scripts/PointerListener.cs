using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using VRTK;

public class PointerListener : MonoBehaviour {
    
    List<Action> _enterEvents = new List<Action>();
    List<Action> _clickEvents = new List<Action>();
    List<Action> _exitEvents = new List<Action>();

    bool _cursor = false;

    void Start()
    {
        var pointer = FindObjectOfType<VRTK_Pointer>() as VRTK_Pointer;
        pointer.DestinationMarkerEnter += OnEnter;
        pointer.DestinationMarkerExit += OnExit;

        var events = FindObjectOfType<VRTK_ControllerEvents>();
        events.TriggerPressed += OnClick;
    }

    void OnDestroy()
    {
        var pointer = FindObjectOfType<VRTK_Pointer>() as VRTK_Pointer;
        pointer.DestinationMarkerEnter -= OnEnter;
        pointer.DestinationMarkerExit -= OnExit;

        var events = FindObjectOfType<VRTK_ControllerEvents>();
        events.TriggerPressed -= OnClick;
    }

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

    public void OnEnter(object sender, DestinationMarkerEventArgs args)
    {
        if (args.target != gameObject.transform) return;

        _enterEvents.ForEach(e => e.Invoke());
        _cursor = true;
    }

    public void OnExit(object sender, DestinationMarkerEventArgs args)
    {
        if (args.target != gameObject.transform) return;

        _cursor = false;
        _exitEvents.ForEach(e => e.Invoke());
    }
    
    public void OnClick(object sender, ControllerInteractionEventArgs args)
    {
        if (!_cursor) return;

        _clickEvents.ForEach(e => e.Invoke());
    }
}
