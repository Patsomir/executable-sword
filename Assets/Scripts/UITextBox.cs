using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UITextBox : MonoBehaviour
{
    [SerializeField]
    private float pixelsPerUnit = 3.2f;
    private float unitsPerPixel;

    [SerializeField]
    private bool rightAligned = false;

    private Image[] targetImages = null;

    [SerializeField]
    private string text = null;

    [SerializeField]
    private GameObject sampleObject = null;

    private void Start()
    {
        unitsPerPixel = 1 / pixelsPerUnit;
        targetImages = new Image[0];
        SetText(text);
    }

    public void SetText(string text)
    {
        for(int i = 0; i < text.Length - targetImages.Length; ++i)
        {
            Instantiate(sampleObject, transform).SetActive(true);
        }
        targetImages = GetComponentsInChildren<Image>();
        this.text = text;
        DisplayDigits();
    }

    private void DisplayDigits()
    {
        float offset = 0;
        float offsetDirection = 1;
        int firstToDisplay = 0;
        if (rightAligned)
        {
            offset = -UIFont.GetGlyphSprite(text[text.Length - 1]).rect.width * unitsPerPixel;
            offsetDirection = -1;
            firstToDisplay = text.Length - 1;
        }

        for (int i = 0; i < text.Length; ++i)
        {
            int currentToDisplay = firstToDisplay + (int)offsetDirection * i;
            targetImages[i].rectTransform.localPosition = new Vector2(
                offset,
                targetImages[i].rectTransform.localPosition.y);
            targetImages[i].rectTransform.sizeDelta = new Vector2(
                UIFont.GetGlyphSprite(text[currentToDisplay]).rect.width * unitsPerPixel,
                UIFont.GetGlyphSprite(text[currentToDisplay]).rect.height * unitsPerPixel);
            if (rightAligned)
            {
                if(currentToDisplay > 0)
                {
                    offset -= UIFont.GetGlyphSprite(text[currentToDisplay - 1]).rect.width * unitsPerPixel;
                }
            } else
            {
                offset += UIFont.GetGlyphSprite(text[currentToDisplay]).rect.width * unitsPerPixel;
            }
            targetImages[i].sprite = UIFont.GetGlyphSprite(text[currentToDisplay]);
            targetImages[i].rectTransform.pivot = GetPivot(targetImages[i].sprite);
            targetImages[i].enabled = true;
        }
        for (int i = text.Length; i < targetImages.Length; ++i)
        {
            targetImages[i].enabled = false;
        }
    }

    private Vector2 GetPivot(Sprite sprite)
    {
        return new Vector2(
                    sprite.pivot.x / sprite.rect.width,
                    sprite.pivot.y / sprite.rect.height
                );
    }
}
