//Berk//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] public float forwardSpeed;
    [SerializeField] public float jumpForce;
    [SerializeField] public float gravity;

    private CharacterController controller;
    private Vector3 velocity;   

    private int desiredLane = 1; // 0:left 1:middle 2:right
    public float laneDistance = 4; //distance betwwen two lane
   
    private bool isGrounded;

    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        velocity.z = forwardSpeed;    

        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore);


        if (controller.isGrounded)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }


        //which lane the character will be
             
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if(desiredLane == 3)
               desiredLane = 2;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if(desiredLane == -1)
               desiredLane = 0;
        }
        
        //calculate where the character will be

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
            else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        
        transform.position = targetPosition;

    }

    private void FixedUpdate()
    {
        controller.Move(velocity * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        velocity.y = jumpForce;
    }
}
