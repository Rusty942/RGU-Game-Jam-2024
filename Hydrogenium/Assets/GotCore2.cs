using UnityEngine;

public class GotCore2 : MonoBehaviour
{
    private CheckForWin2 checkForWin2; // Reference to the CheckForWin script
    private Vector3 startPosition;
    public GotCoreMessage gotCoreMessage;
    public AudioSource collisionAudio; // Reference to the AudioSource component

    void Start()
    {
        startPosition = transform.position;
        checkForWin2 = FindObjectOfType<CheckForWin2>(); 
        if (checkForWin2 == null)
        {
            Debug.LogError("CheckForWin component not found in the scene!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the AudioSource component is valid and is not playing
            if (collisionAudio != null && !collisionAudio.isPlaying)
            {
                collisionAudio.Play();
            }

            // Send debug message
            Debug.Log("Power core collided with Player!");

            // Make the power core disappear after a delay
            StartCoroutine(DestroyAfterDelay());

            // Show the "Got Core" message
            gotCoreMessage.ShowMessage();

            // Call the WinAvailable method of the CheckForWin script if it's not null
            if (checkForWin2 != null)
            {
                checkForWin2.WinAvailable();
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