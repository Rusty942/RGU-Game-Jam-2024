using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Leave : MonoBehaviour
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
        if (playerInRange && Input.GetKeyDown(KeyCode.A))
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("Level 1");
    }
}