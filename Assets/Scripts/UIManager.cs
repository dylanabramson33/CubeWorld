using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject openSlot;

    public void CloseSlot()
    {
        if(openSlot != null)
        {
            openSlot.GetComponent<Animator>().SetTrigger("Close");
        }
    }
}
