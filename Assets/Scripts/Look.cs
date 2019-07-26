using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public GameObject parent;


    // Update is called once per frame
    void Update()
    {
        if (parent.gameObject != null)
        {
            transform.position = parent.transform.position;
            transform.position = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
            transform.LookAt(transform.position + Camera.main.gameObject.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);

        }
        else
        {
            Destroy(this.gameObject);
        }


    }
}
