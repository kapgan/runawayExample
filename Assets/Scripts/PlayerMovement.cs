using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool turnLeft, turnRight,jump;
    [SerializeField]
    private float speed = 7.0f;
    private CharacterController mycharacterController;
  
    void Start()
    {
        mycharacterController = GetComponent<CharacterController>();
       
    }

    private void Update()
    {
        
  
        turnLeft = Input.GetKeyDown(KeyCode.A);
        turnRight = Input.GetKeyDown(KeyCode.D);
        if (Input.GetKeyDown("space"))
            jump = true;
        else
            jump = false;
        if (turnLeft)
            transform.Rotate(new Vector3(0f, -90f, 0f));
        else if (turnRight)
            transform.Rotate(new Vector3(0f, 90f, 0f));
        mycharacterController.SimpleMove(new Vector3(0f, 0f, 0f));
        mycharacterController.Move(transform.forward * speed * Time.deltaTime);
 
    }
}
