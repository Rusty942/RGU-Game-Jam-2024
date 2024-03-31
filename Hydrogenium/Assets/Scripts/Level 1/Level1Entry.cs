using UnityEngine;

public class Level1Entry : MonoBehaviour
{
    private bool playerInRange = false;

    // Coordinates to teleport the player
    private Vector2 teleportPosition = new Vector2(420f, -7.9f);

    // Reference to the background music audio source
    public AudioSource bgMusic;

    // Reference to the audio source attached to this object
    private AudioSource audioSource;

    // Reference to the audio source attached to the empty object
    public AudioSource teleportAudio;

    private void Start()
    {
        // Get the AudioSource component attached to this object
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player in range");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.S))
        {
            TeleportPlayer();
        }
    }

    private void TeleportPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = teleportPosition;
            Debug.Log("Player teleported to (" + teleportPosition.x + ", " + teleportPosition.y + ")");

            // Stop the background music
            if (bgMusic != null)
            {
                bgMusic.Stop();
            }

            // Start the audio source attached to this object
            if (audioSource != null)
            {
                audioSource.Play();
            }

            // Start the teleport audio
            if (teleportAudio != null)
            {
                teleportAudio.Play();
            }
        }
        else
        {
            Debug.LogError("Player not found!");
        }
    }
}