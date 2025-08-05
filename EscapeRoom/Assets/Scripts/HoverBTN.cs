using UnityEngine;
using UnityEngine.EventSystems;

public class HoverBTN : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] private AudioClip hoverClip;
    [SerializeField] private AudioClip clickClip;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverClip != null)
            AudioManager.Instance.PlaySFX(hoverClip);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (clickClip != null)
            AudioManager.Instance.PlaySFX(clickClip);
    }
}
