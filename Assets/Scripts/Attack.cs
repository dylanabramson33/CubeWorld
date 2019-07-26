using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy" && GetComponent<Movement>().canDoDamage)
        {
            other.GetComponent<TakeDamage>().BlowBack(transform.position);
           
        }
        else if(other.gameObject.tag == "Enemy" && GetComponent<Dash>().canDoDamage)
        {
            other.GetComponent<TakeDamage>().BlowBack(transform.position);
        }
    }
}
