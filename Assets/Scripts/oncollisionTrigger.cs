using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oncollisionTrigger : MonoBehaviour
{
  
    private void OnCollisionExit(Collision collision)
    {
       //takozlar yok ediliyor
        if(collision.gameObject.tag=="Ground" || collision.gameObject.tag == "Sea")
        Destroy(collision.gameObject,3);
    }
}
