using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Quaternion startOrientation;
    private bool canMoveAgain = true;
    private Vector3 target_position;
    public bool canDoDamage;
    private bool grounded;
   

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
       


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = false;
        }


    }

   




    void Update()
    {
        if (canMoveAgain)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                StartCoroutine(Rotate90(Vector3.forward, false));
                target_position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                canMoveAgain = false;
                GetComponent<AudioManager>().PlayFootStep();
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                StartCoroutine(Rotate90(Vector3.forward, true));
                target_position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                canMoveAgain = false;
                GetComponent<AudioManager>().PlayFootStep();
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                StartCoroutine(Rotate90(Vector3.right, true));
                target_position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
                canMoveAgain = false;
                GetComponent<AudioManager>().PlayFootStep();
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                StartCoroutine(Rotate90(Vector3.right, false));
                target_position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
                canMoveAgain = false;
                GetComponent<AudioManager>().PlayFootStep();
            }
        }
        else
        {
            if (!grounded)
            {
                transform.position = Vector3.MoveTowards(transform.position, target_position, 2 * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, target_position, 6 * Time.deltaTime);
            }

        }

    }

    private IEnumerator Rotate90(Vector3 axis, bool forwards)
    {

        float multiplier = 1;
        if (grounded)
        {
            canDoDamage = true;
            multiplier = 1.25f;
        }
        if (forwards)
        {
            startOrientation = transform.rotation;
            float amount = 0;

            while (amount > -90)
            {
                yield return new WaitForEndOfFrame();
                var increase = -Time.deltaTime * 400 * multiplier * -amount / 10 - 1;
                amount += increase;
                transform.RotateAround(transform.position, axis, increase);
            }
            transform.rotation = startOrientation;
            transform.RotateAround(transform.position, axis, 90);
            canMoveAgain = true;
            canDoDamage = false;
        }
        else
        {
            startOrientation = transform.rotation;
            float amount = 0;

            while (amount < 90)
            {
                yield return new WaitForEndOfFrame();
                var increase = Time.deltaTime * 400 * multiplier * amount/10 + 1;
                amount += increase;
                transform.RotateAround(transform.position, axis, increase);
            }
            transform.rotation = startOrientation;
            transform.RotateAround(transform.position, axis, 90);
            canMoveAgain = true;
            canDoDamage = false;
            grounded = false;
        }

    }

   
}
