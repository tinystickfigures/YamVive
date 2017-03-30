using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MugshotDatabase : MonoBehaviour {

    [Serializable]
    public class Mugshot
    {
        public string Name;
        public Texture2D Texture;

        public Mugshot(string name, Texture2D texture)
        {
            Name = name;
            Texture = texture;
        }
    }

    private static MugshotDatabase _instance;

    Dictionary<string, Texture2D> _mugshots = new Dictionary<string, Texture2D>();

    public Mugshot[] Mugshots;
    
    void Awake()
    {
        _instance = this;
        
        foreach (var m in Mugshots)
        {
            _mugshots[m.Name] = m.Texture;
        }
    }

    public static Sprite GetMugshot(string name)
    {
        var mugshot = _instance._mugshots[name];
        var spriteRect = new Rect(0, 0, mugshot.width, mugshot.height);
        var spritePivot = new Vector2(0.5f, 0.5f);
        var sprite = Sprite.Create(mugshot, spriteRect, spritePivot);

        return sprite;
    }
}
