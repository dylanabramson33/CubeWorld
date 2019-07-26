using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EquipmentManager : MonoBehaviour
{
    public GameObject legs;
    public GameObject[] baseInventory;
    private float initY;
    public Sprite[] textures;
    private string[] bases = new string[2];
    private bool hasLegs;


    private void Start()
    {

        ChangeBase("Standard");
        bases[0] = "Standard";
        bases[1] = "Standard";
        initY = transform.position.y;

    }

    public void ChangeBase(string newGear)
    {
  
        if (newGear == "Standard")
        {
            bases[0] = "Standard";
            if (hasLegs)
            {
                StartCoroutine("LoseLegs");
            }

            baseInventory[1].GetComponent<Image>().sprite = baseInventory[0].GetComponent<Image>().sprite;
            baseInventory[0].GetComponent<Image>().sprite = textures[0];

        }
        if (newGear == "SpiderLegs")
        {
            bases[0] = "SpiderLegs";
            StartCoroutine("GrowLegs");
            baseInventory[1].GetComponent<Image>().sprite = baseInventory[0].GetComponent<Image>().sprite;
            baseInventory[0].GetComponent<Image>().sprite = textures[1];
           
        }
    }

    public void SwapBases()
    {
        string temp = bases[0];
        bases[0] = bases[1];
        bases[1] = temp;
        ChangeBase(bases[0]);
    }

    IEnumerator GrowLegs()
    {
        transform.rotation = Quaternion.identity;
        for(int x = 0; x < 8; x++)
        {
            yield return new WaitForEndOfFrame();
            transform.position = new Vector3(transform.position.x, transform.position.y + 6 * Time.deltaTime, transform.position.z);
        }
       
        GetComponent<Animator>().SetTrigger("LegsGrow");
        GetComponent<Movement>().enabled = false;
        GetComponent<SpiderLegMovement>().enabled = true;
        GetComponent<Dash>().enabled = true;
        hasLegs = true;
    }

    IEnumerator LoseLegs()
    {
        transform.rotation = Quaternion.identity;
        while (transform.position.y > initY)
        {
            yield return new WaitForEndOfFrame();
            transform.position = new Vector3(transform.position.x, transform.position.y - 6 * Time.deltaTime, transform.position.z);
        }
        GetComponent<Animator>().SetTrigger("LoseLegs");
        GetComponent<Movement>().enabled = true;
        GetComponent<SpiderLegMovement>().enabled = false;
        GetComponent<Dash>().enabled = false;
        hasLegs = false;


    }

}
