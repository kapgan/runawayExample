using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    private bool turnLeft, turnRight, jump;
    [SerializeField]
    private float speed = 7.0f;
    public bool grounded = true;
    [SerializeField]
    private float gravity = 9.8f;
    [SerializeField]
    private float jumpPower = 10f;

    private float directionY;
    private CharacterController mycharacterController;
    public float x, y, z = 0f;
    public bool devam = true;
    void Start()
    {
        mycharacterController = GetComponent<CharacterController>();

    }
    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
  
    void OnCollisionExit(Collision hit)
    {
        if (hit.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (devam == true)
                devam = false;
            else
                devam = true;
        }

        if (devam == true)
        {
            Vector3 direction = new Vector3(x, y, z);
            turnLeft = Input.GetKeyDown(KeyCode.A);
            turnRight = Input.GetKeyDown(KeyCode.D);

            if (Input.GetKeyDown("space"))
            {
                jump = true;
            }
            else
                jump = false;

            if (turnLeft)
                transform.Rotate(new Vector3(0f, -90f, 0f));
            else if (turnRight)
                transform.Rotate(new Vector3(0f, 90f, 0f));

            if (jump == true && mycharacterController.isGrounded)
            {
                directionY = jumpPower;

            }

            directionY -= gravity * Time.deltaTime;
            direction.y = directionY;
            direction += transform.forward;
            mycharacterController.Move(direction * speed * Time.deltaTime);

        }


    }

}
