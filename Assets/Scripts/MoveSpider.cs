using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpider : MonoBehaviour
{
    private bool startled;
    Vector3 initPosition;
    Vector3 playerPosition;
    Vector3 targetPosition;
    bool canPickNewPosition = true;
    bool canDashAgain = true;
    bool startingLeap;

    

   


    void Start()
    {
        initPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<TakeDamage>().canMoveAgain)
        {
            playerPosition = GameObject.Find("MainCharacter").transform.position;
            if (Vector3.Distance(playerPosition, transform.position) < 6f)
            {
                startled = true;
            }


            if (!startled)
            {
                DefaultBehavior();
            }
            else
            {
                PursueBehavior();
            }
        }

    }

    void DefaultBehavior()
    {
        if (canPickNewPosition)
        {
            targetPosition = 10 * Random.insideUnitSphere.normalized;
            canPickNewPosition = false;
           
        }
        else
        {
           
            if (Vector3.Distance(transform.position, initPosition + new Vector3(targetPosition.x, 0, targetPosition.z)) < .1f)
            {
                canPickNewPosition = true;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, initPosition + new Vector3(targetPosition.x, 0, targetPosition.z), 2 * Time.deltaTime);
            }
        }
    }

    void PursueBehavior()
    {

        if (Vector3.Distance(playerPosition, transform.position) < 6f && canDashAgain && !startingLeap)
        {
            startingLeap = true;
            canDashAgain = false;
            StartCoroutine(SubtlePause());
        }
        else if (!startingLeap)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, 2 * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, -1 * playerPosition, 0.5f * Time.deltaTime);
        }
    }

    IEnumerator SubtlePause()
    {
        yield return new WaitForSeconds(0.2f);
        GetComponent<Dash>().DashTowardsPoint(playerPosition);
        StartCoroutine(WaitForDash());
        startingLeap = false;
    }

    IEnumerator WaitForDash()
    {
        yield return new WaitForSeconds(2f);
        canDashAgain = true;
    }
}
