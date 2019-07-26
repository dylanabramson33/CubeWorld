using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(Random.Range(6, 15), Random.Range(6, 15), Random.Range(6, 15));
        transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
    }


}
