using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropGoodie : MonoBehaviour
{
    public GameObject goodie;


    public void Drop()
    {
        Instantiate(goodie, transform.position, Quaternion.identity);
    }
}
