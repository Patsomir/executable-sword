using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSoundManager : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        SoundManager.Select();
    }
}
