using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public float forwardSpeed;
    public float backwardSpeed;
    public float strafeSpeed;

    //Animation stuff
    float animationX = 0;
    float xVelocity = 0;
    float xSmoothTime = 0.05f;

    float animationY = 0;
    float yVelocity = 0;
    float ySmoothTime = 0.05f;
    //Animation stuff ends here

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 movement = Vector3.zero;
        //this is (0,0,0)

        if (inputZ > 0)
        {
            //Adds the distance the player is going to move this frame in the direction theyre facing
            movement += transform.forward * inputZ * forwardSpeed * Time.deltaTime;
            //Adds the distance the player is going to move this frame to their right
            movement += transform.right * inputX * strafeSpeed * Time.deltaTime;
        }
        else
        {
            //Adds the distance the player is going to move this frame back (because inputZ is negative)
            movement += transform.forward * inputZ * backwardSpeed * Time.deltaTime;
            //Adds the distance the player is going to move this frame to their left (because inputX is negative)
            movement += transform.right * inputX * strafeSpeed * Time.deltaTime;
        }

        controller.Move(movement);

        //Animation stuff begins here
        animationX = Mathf.SmoothDamp(animationX, inputX, ref xVelocity, 0.3f);
        animationY = Mathf.SmoothDamp(animationY, inputZ, ref yVelocity, 0.3f);

        animator.SetFloat("X", animationX);
        animator.SetFloat("Y", animationY);

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("Jump");
        }
        //Animation stuff ends here
    }
}
