using UnityEngine;
using UnityEngine.UI;

public class UINumberBox : MonoBehaviour
{
    [SerializeField]
    private Sprite[] digitSource = null;

    [SerializeField]
    private Image[] digitTarget = null;

    [SerializeField]
    private float pixelsPerUnit = 3.2f;
    private float unitsPerPixel;

    [SerializeField]
    private bool rightAligned = false;

    private void Start()
    {
        unitsPerPixel = 1 / pixelsPerUnit;
    }

    public void SetNumber(int number)
    {
        int[] digits = new int[digitTarget.Length];
        int digitCount = 1;
        int tempNumber = number;
        digits[0] = tempNumber % 10;
        tempNumber /= 10;

        while(tempNumber > 0)
        {
            digits[digitCount] = tempNumber % 10;
            tempNumber /= 10;
            ++digitCount;
        }

        DisplayDigits(digits, digitCount);
    }

    private void DisplayDigits(int[] digits, int digitCount)
    {
        float offset = 0;
        float offsetDirection = 1;
        int firstToDisplay = digitCount - 1;
        if (rightAligned)
        {
            offset = -digitSource[digits[0]].rect.width * unitsPerPixel;
            offsetDirection = -1;
            firstToDisplay = 0;
        }

        for (int i = 0; i < digitCount; ++i)
        {
            int currentToDisplay = firstToDisplay - (int)offsetDirection * i;
            digitTarget[i].rectTransform.localPosition = new Vector2(
                offset,
                digitTarget[i].rectTransform.localPosition.y);
            digitTarget[i].rectTransform.sizeDelta = new Vector2(
                digitSource[digits[currentToDisplay]].rect.width * unitsPerPixel,
                digitSource[digits[currentToDisplay]].rect.height * unitsPerPixel);
            if (rightAligned)
            {
                if (currentToDisplay < digitCount - 1)
                {
                    offset -= digitSource[digits[currentToDisplay + 1]].rect.width * unitsPerPixel;
                }
            } else
            {
                offset += digitSource[digits[currentToDisplay]].rect.width * unitsPerPixel;
            }
            digitTarget[i].sprite = digitSource[digits[currentToDisplay]];
            digitTarget[i].enabled = true;
        }
        for (int i = digitCount; i < digitTarget.Length; ++i)
        {
            digitTarget[i].enabled = false;
        }
    }
    
}
