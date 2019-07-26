using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip footStepSound;
    public AudioClip inventorySwitch;
    public AudioClip equipSound;

    public void PlayFootStep()
    {
        GetComponent<AudioSource>().PlayOneShot(footStepSound,2f);
    }
    public void PlayInventorySwitch()
    {
        GetComponent<AudioSource>().PlayOneShot(inventorySwitch, 2f);
    }
    public void PlayEquipSound()
    {
        GetComponent<AudioSource>().PlayOneShot(equipSound, 2f);
    }
}
