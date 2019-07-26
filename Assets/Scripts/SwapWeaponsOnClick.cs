using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SwapWeaponsOnClick : MonoBehaviour, IPointerDownHandler
{
    private GameObject player;
   
    private void Start()
    {
        player = GameObject.Find("MainCharacter");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        player.GetComponent<EquipmentManager>().SwapBases();
        player.GetComponent<AudioManager>().PlayInventorySwitch();
    
    }
}
