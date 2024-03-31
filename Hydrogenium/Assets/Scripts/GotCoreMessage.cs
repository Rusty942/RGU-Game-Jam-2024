using UnityEngine;
using TMPro;
using System.Collections;
public class GotCoreMessage : MonoBehaviour
{
    private void Start()
    {
        // Ensure the text mesh is initially inactive
        gameObject.SetActive(false);
    }

    public void ShowMessage()
    {
        // Show the TextMeshPro object
        gameObject.SetActive(true);
        // Start a coroutine to hide the message after a delay
        StartCoroutine(HideMessageAfterDelay());
    }

    // Coroutine to hide the message after a delay
    private IEnumerator HideMessageAfterDelay()
    {
        // Wait for 1 second
        yield return new WaitForSeconds(2f);
        // Hide the TextMeshPro object
        gameObject.SetActive(false);
    }
}