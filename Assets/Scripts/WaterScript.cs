using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]

    GameObject player;
    Vector3 aradakifark;
    Vector3 temp;

    // Use this for initialization
    void Start()
    {
        aradakifark = transform.position - player.transform.position;
        aradakifark = new Vector3(aradakifark.x,-aradakifark.y,aradakifark.z);
        //aradaki farký buluyoruz
    }

    // Update is called once per frame
    void Update()
    {
        temp = player.transform.position;
        temp.y = 0f;
        aradakifark.y = 0f;
        transform.position = temp + aradakifark;

    }
}
