using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{

    public int speed;
    public bool canDoDamage;
    public void DashTowardsPoint(Vector3 point)
    {
        Vector3 direction = point - transform.position;
        StartCoroutine(DashRoutine(direction));
        
    }

    IEnumerator DashRoutine(Vector3 direction)
    {
        for(int x = speed; x > 0; x-= 3)
        {
            yield return new WaitForEndOfFrame();
            canDoDamage = true;
            transform.position += direction.normalized * x/1.25f * Time.deltaTime;
            
        }
        canDoDamage = false;
    }
}
