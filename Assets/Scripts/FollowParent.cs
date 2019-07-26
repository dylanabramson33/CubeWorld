using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowParent : MonoBehaviour
{
    GameObject enemy;
    public GameObject cameraMain;
    public float sliderX;
    public float sliderY;
    public float sliderZ;
    private void Start()
    {
        enemy = GameObject.Find("SpiderParent");
        cameraMain = GameObject.Find("Main Camera");
    }

    private void Update()
    {

        Vector3 desiredPos = new Vector3(enemy.transform.position.x + sliderX, enemy.transform.position.y + sliderY, enemy.transform.position.z + sliderZ);
        Vector3 wantedPos = cameraMain.GetComponent<Camera>().WorldToScreenPoint(desiredPos);
        transform.position = wantedPos;
    }

}
