using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public AudioSource jumpSound; // Reference to the AudioSource component for jump sound
    public AudioSource waterSpurt;
    private List<WaterFill> waterFills = new List<WaterFill>(); // List to store references to WaterFill components

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool canUseWater = false;

    // Moves logic
    private bool isShooting = false;
    bool isFillingWater = false;

    private Animator animator; // Reference to the Animator component

    void Start ()
    {
        // Get the Animator component attached to the same GameObject
        animator = GetComponent<Animator>();

        // Get the AudioSource component attached to the same GameObject
        jumpSound = GetComponent<AudioSource>();

        // Find all instances of WaterFill in the scene and store them in the list
        WaterFill[] foundWaterFills = FindObjectsOfType<WaterFill>();
        foreach (WaterFill foundWaterFill in foundWaterFills)
        {
            waterFills.Add(foundWaterFill);
        }

        if (waterFills.Count == 0)
        {
            Debug.LogError("No WaterFill components found in the scene!");
        }
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
                animator.SetBool("Jumping", true);
                // Play jump sound
                jumpSound.Play();
            }

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }

        // Handle shooting input
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canUseWater == true) 
            {
                isShooting = true;
                animator.SetBool("ShootingWater", true);
                horizontalMove = 0f; // Stop horizontal movement while shooting
                Debug.Log("shooting water");
                foreach (WaterFill waterFill in waterFills)
                {
                    waterFill.FillUp(); // Call FillUp method on each WaterFill instance
                }
                isFillingWater = true;
                waterSpurt.Play(); 
            }
            else
            {
                isShooting = true;
                animator.SetBool("Shooting", true);
                horizontalMove = 0f; // Stop horizontal movement while shooting   
                isFillingWater = false;          
            }
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            isShooting = false;
            animator.SetBool("Shooting", false);
            animator.SetBool("ShootingWater", false);
            isFillingWater = false; 
            waterSpurt.Stop();
        }

        if (isFillingWater)
        {
            foreach (WaterFill waterFill in waterFills)
            {
                waterFill.FillUp(); // Call FillUp method on each WaterFill instance
            }
        }
    }
    

    public void OnLanding()
    {
        animator.SetBool("Jumping", false);
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

    public void WaterAvailable()
    {
        canUseWater = true;
        Debug.Log("Water available");
    }
}