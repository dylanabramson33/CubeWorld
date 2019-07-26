using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackHealth : MonoBehaviour
{
    private float health;
    private Image image;
    public float maxHealth;
    public float currentHealth; 

    void Start()
    {
        image = GetComponent<Image>();
        image.fillAmount = 1;


    }

    public void UpdateHealth(float currentHealth)
    {
        image.fillAmount = currentHealth / maxHealth;

    }
}
