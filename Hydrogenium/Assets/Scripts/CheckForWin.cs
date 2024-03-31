using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class CheckForWin : MonoBehaviour
{
    private bool playerInRange = false;
    bool haveCore = false;
    private GeneratorFix generatorFix;
    public TextMeshProUGUI winText;
    public TextMeshPro extraText; // Additional TextMeshProUGUI to hide at win
    public SpriteRenderer extraSprite; // Additional SpriteRenderer to hide at win

    private void Start()
    {
        generatorFix = FindObjectOfType<GeneratorFix>();
        winText.gameObject.SetActive(false); // Hide the win text initially
        extraText.gameObject.SetActive(true); // Show the extra text initially
        extraSprite.enabled = true; // Show the extra sprite initially
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player in range");
            if (haveCore)
            {
                Debug.Log("You win");
                generatorFix.Win();
                StartCoroutine(WinCoroutine()); // Start the coroutine to delay freezing
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private IEnumerator WinCoroutine()
    {
        yield return new WaitForSeconds(1f); // Adjust the delay time as needed

        ShowWinText();
        HideExtraComponents();

        yield return new WaitForSeconds(3f); // Wait for 3 seconds after win text shows up

        MoveToNextScene();
    }

    private void ShowWinText()
    {
        winText.gameObject.SetActive(true); // Show the win text
        winText.text = "You Win!";
    }

    private void HideExtraComponents()
    {
        extraText.gameObject.SetActive(false); // Hide the extra text
        extraSprite.enabled = false; // Hide the extra sprite
    }

    private void MoveToNextScene()
    {
        // Replace "NextSceneName" with the name of your next scene
        SceneManager.LoadScene("Hub");
    }

    public void WinAvailable()
    {
        haveCore = true;
        Debug.Log("Grabbed hydrogen core");
    }
}