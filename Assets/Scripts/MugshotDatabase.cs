using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MugshotDatabase : MonoBehaviour {

    [Serializable]
    public class Mugshot
    {
        public string Name;
        public int ID;
        public Texture2D Texture;

        public Mugshot(string name, int id, Texture2D texture)
        {
            Name = name;
            ID = id;
            Texture = texture;
        }
    }

    private static MugshotDatabase _instance;

    Dictionary<int, Texture2D> _mugshots = new Dictionary<int, Texture2D>();
    Dictionary<int, string> _names = new Dictionary<int, string>();

    public Mugshot[] Mugshots;
    
    void Awake()
    {
        _instance = this;
        
        foreach (var m in Mugshots)
        {
            _mugshots[m.ID] = m.Texture;
            _names[m.ID] = m.Name;
        }
    }

    public static Sprite GetMugshot(int id)
    {
        var mugshot = _instance._mugshots[0];

        if (_instance._mugshots.ContainsKey(id))
        {
            mugshot = _instance._mugshots[id];
        }
        
        var spriteRect = new Rect(0, 0, mugshot.width, mugshot.height);
        var spritePivot = new Vector2(0.5f, 0.5f);
        var sprite = Sprite.Create(mugshot, spriteRect, spritePivot);

        return sprite;
    }

    public static string GetName(int id)
    {
        if (_instance._names.ContainsKey(id))
        {
            return _instance._names[id];
        }
        return "Dobby";
    }
}
