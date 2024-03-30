using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed of the character
    private Animator animator; // Reference to the Animator component
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    // Start is called before the first frame update
    void Start()
    {
        // Get the Animator component attached to the same GameObject
        animator = GetComponent<Animator>();

        // Get the SpriteRenderer component attached to the same GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal input (A and D keys or left and right arrow keys)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the movement amount
        float movement = horizontalInput * moveSpeed * Time.deltaTime;

        // Move the character
        transform.Translate(new Vector3(movement, 0f, 0f));

        // Update the walking animation
        UpdateWalkingAnimation(horizontalInput);

        // Flip the character sprite if moving left
        FlipCharacter(horizontalInput);
    }

    // Function to update the walking animation based on input
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

    // Function to flip the character sprite based on movement direction
    private void FlipCharacter(float horizontalInput)
    {
        // If moving left, flip the sprite horizontally
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        // If moving right, flip the sprite back to its original orientation
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}