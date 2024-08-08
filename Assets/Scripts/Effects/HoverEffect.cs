using UnityEngine;
using UnityEngine.EventSystems;

public class HoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject objToShow;
    public GameObject objToHide;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (objToShow != null)
        {
            objToShow.SetActive(true);
        }

        if (objToHide != null)
        {
            objToHide.SetActive(false);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (objToShow != null)
        {
            objToShow.SetActive(false);
        }

        if (objToHide != null)
        {
            objToHide.SetActive(true);
        }
    }
}