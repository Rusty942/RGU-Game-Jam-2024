using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenItem : MonoBehaviour
{
    private PlayerMovement playerMovement; // Reference to the PlayerMovement script
    public float bobSpeed = 1f; // Speed of the bobbing motion
    public float bobHeight = 0.5f;
    public OxygenMessage oxygenMessage; // Reference to the OxygenMessage script attached to the TextMeshPro object
    public AudioSource collisionAudio; // Reference to the AudioSource component for collision sound

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
        // Calculate the new position based on a sine wave
        float newY = startPosition.y + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Play collision sound
            if (collisionAudio != null)
            {
                collisionAudio.Play();
            }

            // Send debug message
            Debug.Log("Oxygen Item collided with Player!");

            // Make the oxygen item disappear after a delay
            StartCoroutine(DestroyAfterDelay());

            // Activate the TextMeshPro object
            oxygenMessage.ShowMessage();

            // Call the WaterAvailable method of the PlayerMovement script if it's not null
            if (playerMovement != null)
            {
                playerMovement.WaterAvailable();
            }
        }
    }

    private System.Collections.IEnumerator DestroyAfterDelay()
    {
        // Wait for the audio clip to finish playing before destroying the object
        yield return new WaitForSeconds(collisionAudio.clip.length);

        // Destroy the object
        Destroy(gameObject);
    }
}