using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPoint : MonoBehaviour
{
    GameObject mainCharacter;
    Vector3 camOffset;
    Vector3 newPos;

    private void Start()
    {
        mainCharacter = GameObject.Find("MainCharacter");
        camOffset = transform.position - mainCharacter.transform.position;

    }

    void LateUpdate()
    {
        newPos = mainCharacter.transform.position + camOffset;
        if (Input.GetKey(KeyCode.D))
        {
            Rotate(false);

        }
        else if (Input.GetKey(KeyCode.A))
        {
            Rotate(true);
        }

        transform.position = Vector3.Slerp(transform.position, newPos, 20f);
        transform.LookAt(mainCharacter.transform);
        



    }

    void Rotate(bool left)
    {

       
   
        if (left && WrapAngle(transform.rotation.eulerAngles.y) < 30)
        {
                Quaternion camTurnAngle = Quaternion.AngleAxis(2.5f, Vector3.up);
                camOffset = camTurnAngle * camOffset;
                newPos = mainCharacter.transform.position + camOffset;
                transform.position = Vector3.Lerp(transform.position, newPos, 5f);
        }


        if(!left && WrapAngle(transform.rotation.eulerAngles.y) > -30)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(-2.5f, Vector3.up);
            camOffset = camTurnAngle * camOffset;
            newPos = mainCharacter.transform.position + camOffset;
            transform.position = Vector3.Lerp(transform.position, newPos, 5f);
        }
        

    


    }
    
    float WrapAngle(float angle)
    {
        angle %= 360;
        if (angle > 180)
            return angle - 360;

        return angle;
    }
}
    
