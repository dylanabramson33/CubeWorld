using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnHoverShowMenu : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<Animator>().SetTrigger("SlideOut");
        GetComponentInParent<UIManager>().openSlot = gameObject;
    }








}
