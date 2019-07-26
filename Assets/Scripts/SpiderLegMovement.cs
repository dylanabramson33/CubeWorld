using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderLegMovement : MonoBehaviour
{

    private bool canMoveAgain = true;
    private bool canDashAgain = true;
    private Vector3 direction;

    void Update()
    {
        if (canMoveAgain)
        {
            direction = Vector3.zero;
            if (Input.GetKey(KeyCode.LeftArrow))
            {

                transform.position = new Vector3(transform.position.x - 4 * Time.deltaTime, transform.position.y, transform.position.z);
                direction += -1 * transform.right;

            }
            if (Input.GetKey(KeyCode.RightArrow))
            {

                transform.position = new Vector3(transform.position.x + 4 * Time.deltaTime, transform.position.y, transform.position.z);
                direction += transform.right;

            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 4 * Time.deltaTime);
                direction += -1 * transform.forward;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 4 * Time.deltaTime);
                direction += transform.forward;
            }
            if (Input.GetKeyDown(KeyCode.H) && canDashAgain)
            {
                StartCoroutine("WaitForDash");
                GetComponent<Dash>().DashTowardsPoint(transform.position + 4 * direction);
                canDashAgain = false;
            }
        }
    }

    IEnumerator WaitForDash()
    {
        yield return new WaitForSeconds(2f);
        canDashAgain = true;
    }
}
