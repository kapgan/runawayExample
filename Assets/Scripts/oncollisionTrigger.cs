using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oncollisionTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("--------------- " + collision.gameObject.tag);
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("asdas"+collision.gameObject.tag);
        if(collision.gameObject.tag=="Ground" || collision.gameObject.tag == "Sea")
        Destroy(collision.gameObject,3);
    }
}