using UnityEngine;

public class GotCore: MonoBehaviour
{
    private PlayerMovement playerMovement; // Reference to the PlayerMovement script
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        playerMovement = FindObjectOfType<PlayerMovement>(); // Search for PlayerMovement in the scene
        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement component not found in the scene!");
        }
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Send debug message
            Debug.Log("Power core Item collided with Player!");

            // Make the oxygen item disappear
            gameObject.SetActive(false);

            // Call the WaterAvailable method of the PlayerMovement script if it's not null
            if (playerMovement != null)
            {
                playerMovement.WinAvailable();
            }
        }
    }
}