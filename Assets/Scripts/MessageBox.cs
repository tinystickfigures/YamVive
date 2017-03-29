using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using VRTK;

[RequireComponent(typeof(PointerResponder))]
public class MessageBox : MonoBehaviour
{
    public float Amplitude = 0.1f;
    public float Speed = 3f;

    float _y0;

    Text _text;

    void Awake()
    {
        _y0 = gameObject.transform.position.y;

        var pointerResponder = GetComponent<PointerResponder>();
        pointerResponder.AddOnClickEvent(OnClick);
        pointerResponder.AddOnEnterEvent(OnEnter);
        pointerResponder.AddOnExitEvent(OnExit);

        _text = GetComponentInChildren<Text>();
        _text.color = Color.gray;
    }
	
	void Update ()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, _y0 + Amplitude * Mathf.Sin(Speed * Time.time));
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
