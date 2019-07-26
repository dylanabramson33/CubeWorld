using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public GameObject healthBarObject;
    private GameObject healthBar;
    public float maxHealth;
    public float currentHealth;


    void Awake()
    {
        healthBar = Instantiate(healthBarObject);
        healthBar.GetComponent<Look>().parent = this.gameObject;
        healthBar.GetComponentInChildren<TrackHealth>().maxHealth = maxHealth;
        currentHealth = maxHealth;


    }

    public void ChangeHealth(float changeBy)
    {
        currentHealth += changeBy;
        healthBar.GetComponentInChildren<TrackHealth>().UpdateHealth(currentHealth);
        if(currentHealth < 1)
        {
            GetComponentInChildren<Animator>().SetTrigger("Destroy");
            StartCoroutine("WaitToDrop");
            Destroy(this.gameObject, 1f);
        }
    }

    IEnumerator WaitToDrop()
    {
        yield return new WaitForSeconds(.9f);
        GetComponent<DropGoodie>().Drop();

    }



}
