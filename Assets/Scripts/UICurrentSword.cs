using UnityEngine;
using UnityEngine.UI;

public class UICurrentSword : MonoBehaviour
{
    private float maxHeight;
    private float midPosY;

    [SerializeField]
    private Shooter source = null;

    [SerializeField]
    private RectTransform rectTransform = null;

    [SerializeField]
    private Image targetImage = null;

    void Start()
    {
        maxHeight = rectTransform.sizeDelta.y;
        midPosY = rectTransform.localPosition.y - maxHeight/2;
    }

    void Update()
    {
        float height = maxHeight * (source.GetReloadTimeLeft() / source.GetCurrentWeaponReloadTime());
        rectTransform.localPosition = new Vector2(rectTransform.localPosition.x, midPosY + height/2);
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, height);
        targetImage.sprite = source.GetCurrentWeaponBullet().GetComponent<SpriteRenderer>().sprite;
    }
}
