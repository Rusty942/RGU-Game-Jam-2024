using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed of the character
    public float jumpForce = 10f; // Force applied when jumping
    private Animator animator; // Reference to the Animator component
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private BoxCollider2D boxCollider; // Reference to the BoxCollider2D component

    // Start is called before the first frame update
    void Start()
    {
        // Get the Animator component attached to the same GameObject
        animator = GetComponent<Animator>();

        // Get the SpriteRenderer component attached to the same GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Get the Rigidbody2D component attached to the same GameObject
        rb = GetComponent<Rigidbody2D>();

        // Get the BoxCollider2D component attached to the same GameObject
        boxCollider = GetComponent<BoxCollider2D>();
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

        // Flip the character sprite and collider if moving left
        FlipCharacter(horizontalInput);

        // Check for jump input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
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

    // Function to flip the character sprite and collider based on movement direction
    private void FlipCharacter(float horizontalInput)
    {
        // If moving left, flip the sprite and collider horizontally
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
            boxCollider.offset = new Vector2(-boxCollider.offset.x, boxCollider.offset.y);
        }
        // If moving right, flip the sprite and collider back to their original orientation
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
            boxCollider.offset = new Vector2(-boxCollider.offset.x, boxCollider.offset.y);
        }
    }

    // Function to handle player jumping
    private void Jump()
    {
        // Check if the player is grounded (you may need to implement your own grounded check)
        // For simplicity, this example assumes the player is always grounded
        // You may need to replace this with your own grounded check
        // e.g., using a RaycastHit2D or checking if the player is colliding with the ground
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}