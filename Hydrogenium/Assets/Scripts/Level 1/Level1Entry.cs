using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Entry : MonoBehaviour
{
    private bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("touching");
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.S))
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("Level 1 LAB");
    }
}
