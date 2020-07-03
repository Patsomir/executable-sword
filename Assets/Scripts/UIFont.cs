using System;
using System.Collections.Generic;
using UnityEngine;

public class UIFont : MonoBehaviour
{
    [SerializeField]
    private Glyph[] glyphs = null;

    private Dictionary<char, Sprite> font = null;

    private static UIFont instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            instance.font = new Dictionary<char, Sprite>();
            foreach(Glyph i in glyphs)
            {
                instance.font.Add(i.symbol, i.image);
            }
        }
    }

    public static Sprite GetGlyphSprite(char symbol)
    {
        instance.font.TryGetValue(symbol, out Sprite image);
        return image;
    }

    [Serializable]
    class Glyph
    {
        public char symbol = 'A';
        public Sprite image = null;
    }
}
