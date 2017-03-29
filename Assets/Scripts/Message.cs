using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using VRTK;

[RequireComponent(typeof(PointerListener))]
public class Message : MonoBehaviour
{
    public float Amplitude = 0.1f;
    public float Speed = 3f;

    float _y0;

    Text _text;

    public string Text
    {
        get { return _text.text; }
        set { _text.text = value; }
    }

    void Awake()
    {
        var pointerResponder = GetComponent<PointerListener>();
        pointerResponder.AddOnClickEvent(OnClick);
        pointerResponder.AddOnEnterEvent(OnEnter);
        pointerResponder.AddOnExitEvent(OnExit);

        _text = GetComponentInChildren<Text>();
        _text.color = Color.gray;
    }
	
	void Update ()
    {
        if (_y0 == 0)
        {
            _y0 = gameObject.transform.position.y;
        }

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, _y0 + Amplitude * Mathf.Sin(Speed * Time.time), gameObject.transform.position.z);
    }

    public void OnClick()
    {
        _text.color = Color.red;
    }

    public void OnEnter()
    {
        _text.color = Color.white;
    }

    public void OnExit()
    {
        _text.color = Color.gray;
    }
}
