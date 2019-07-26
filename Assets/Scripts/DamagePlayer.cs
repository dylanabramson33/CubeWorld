using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && !collision.gameObject.GetComponent<Movement>().canDoDamage) 
        {
            collision.gameObject.GetComponent<TakeDamage>().BlowBack(transform.position);
        }
        else if(collision.gameObject.tag == "Player" && !collision.gameObject.GetComponent<Dash>().canDoDamage)
        {
            collision.gameObject.GetComponent<TakeDamage>().BlowBack(transform.position);
        }
    }
}
