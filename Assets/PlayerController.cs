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

    float animationX = 0;
    float xVelocity = 0;
    float xSmoothTime = 0.05f;

    float animationY = 0;
    float yVelocity = 0;
    float ySmoothTime = 0.05f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("Jump");
        }

        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        animationX = Mathf.SmoothDamp(animationX, inputX, ref xVelocity, 0.3f);
        animationY = Mathf.SmoothDamp(animationY, inputZ, ref yVelocity, 0.3f);

        animator.SetFloat("X", animationX);
        animator.SetFloat("Y", animationY);

        Vector3 movement;

        if (inputZ > 0)
        {
            movement = new Vector3(inputX * strafeSpeed * Time.deltaTime,
                0, inputZ * forwardSpeed * Time.deltaTime);
        }
        else
        {
            movement = new Vector3(inputX * strafeSpeed * Time.deltaTime,
                0, inputZ * backwardSpeed * Time.deltaTime);
        }

        controller.Move(movement);
    }
}
