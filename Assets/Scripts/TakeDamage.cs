using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{

    private bool canTakeDamageAgain = true;
    public bool canMoveAgain = true;
    private bool player;

    public void BlowBack(Vector3 otherPosition)
    {
        if (canTakeDamageAgain)
        {
            Vector3 direction = transform.position - otherPosition;
            direction = new Vector3(direction.x, 0, direction.z);
            StartCoroutine(Slide(direction));
            canTakeDamageAgain = false;
            canMoveAgain = false;
            GetComponentInChildren<Animator>().SetTrigger("TakeDamage");

        }
        if(GetComponent<HealthController>() != null)
        {
            GetComponent<HealthController>().ChangeHealth(-1);
        }


    }

    IEnumerator Slide(Vector3 direction)
    {
        for(int x = 30; x > 0; x-=2)
        {

            transform.position += direction.normalized * x * Time.deltaTime;
            yield return new WaitForEndOfFrame();
           
        }
        canTakeDamageAgain = true;
        StartCoroutine(MoveAgain()); 
    }

    IEnumerator MoveAgain()
    {
        yield return new WaitForSeconds(0.25f);
        canMoveAgain = true;
    }



}
