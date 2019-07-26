using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEquiped : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,GameObject.Find("MainCharacter").transform.position) < 3f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject.Find("MainCharacter").GetComponent<EquipmentManager>().ChangeBase("SpiderLegs");
                GameObject.Find("MainCharacter").GetComponent<AudioManager>().PlayEquipSound();
                Destroy(this.gameObject);
            }
            GetComponentInChildren<Animator>().SetBool("WithinRadius",true);
        }
        else
        {
            GetComponentInChildren<Animator>().SetBool("WithinRadius", false);
        }
    }
}
