using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2LabLeave : MonoBehaviour
{
    private bool playerInRange = false;

    // Coordinates to teleport the player
    private Vector2 teleportPosition = new Vector2(29f, -5f);

    // Public audio sources to be assigned in the Unity Editor
    public AudioSource bgMusic;
    public AudioSource leaveAudio;
    public AudioSource thirdAudio; // Third audio source

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
        if (playerInRange && Input.GetKeyDown(KeyCode.A))
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

            // Play the leave audio
            if (leaveAudio != null)
            {
                leaveAudio.Play();
            }

            // Play the third audio
            if (thirdAudio != null)
            {
                thirdAudio.Play();
            }
        }
        else
        {
            Debug.LogError("Player not found!");
        }
    }
}
