using UnityEngine;
using UnityEngine.SceneManagement;

public class Lvl2WaterCheck1: MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D player)
    {
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        if (player.CompareTag("Player"))
        {
            playerMovement.IsInRange();
        }
        else{
            playerMovement.OutRange();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
{
    PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
    if (other.CompareTag("Player"))
    {
        playerMovement.OutRange();
    }
}
}
