using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PointerListener))]
public class MessageBox : MonoBehaviour
{
    public float Amplitude = 0.1f;
    public float Speed = 3f;

    float _y0;

    public Text MessageText;
    public Text NameText;
    public Image MugshotImage;

    public string Message
    {
        get { return MessageText.text; }
        set { MessageText.text = value; }
    }

    void Awake()
    {
        var pointerResponder = GetComponent<PointerListener>();
        pointerResponder.AddOnClickEvent(OnClick);
        pointerResponder.AddOnEnterEvent(OnEnter);
        pointerResponder.AddOnExitEvent(OnExit);
        
        MessageText.color = Color.gray;

        Amplitude += Random.Range(-Amplitude / 2f, Amplitude / 2f);
        Speed += Random.Range(-1f, 1f);
    }
	
	void Update ()
    {
        if (_y0 == 0)
        {
            _y0 = gameObject.transform.position.y;
        }

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, _y0 + Amplitude * Mathf.Sin(Speed * Time.time), gameObject.transform.position.z);
    }
    
    public void PopulateNameAndMugshot(int id)
    {
        NameText.text = MugshotDatabase.GetName(id);
        MugshotImage.sprite = MugshotDatabase.GetMugshot(id);
    }

    public void OnClick()
    {
        Destroy(gameObject);
    }

    public void OnEnter()
    {
        MessageText.color = Color.white;
    }

    public void OnExit()
    {
        MessageText.color = Color.gray;
    }

    void OnDestroy()
    {
        Debug.Log("Destroyed");
    }
}
