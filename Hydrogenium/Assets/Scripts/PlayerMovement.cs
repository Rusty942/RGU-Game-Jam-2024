using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
    
    
    //Moves logic
    private bool isShooting = false;

    private Animator animator; // Reference to the Animator component

    void Start ()
    {
        // Get the Animator component attached to the same GameObject
        animator = GetComponent<Animator>();
    }
	
	void Update()
    {
        // Update the walking animation
        UpdateWalkingAnimation(horizontalMove);

        // Check for shooting input
        if (!isShooting)
        {
            // Handle movement input only if not shooting
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            // Check for jump input
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
        }

        // Handle shooting input
        if (Input.GetKeyDown(KeyCode.E))
        {
            isShooting = true;
            animator.SetBool("Shooting", true);
            horizontalMove = 0f; // Stop horizontal movement while shooting
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            isShooting = false;
            animator.SetBool("Shooting", false);
        }
}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
	}

    private void UpdateWalkingAnimation(float horizontalInput)
    {
        // If the horizontal input is not zero, set the "Walking" parameter to true
        // Otherwise, set it to false
        if (horizontalInput != 0)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }
}