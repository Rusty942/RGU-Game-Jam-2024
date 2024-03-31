using UnityEngine;
using TMPro;

public class WinMessage : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        // Get the TextMeshPro component attached to this GameObject
        textMeshPro = GetComponent<TextMeshProUGUI>();

        // Hide the TextMeshPro object initially
        textMeshPro.gameObject.SetActive(false);
    }

    // Method to show the TextMeshPro object when called
    public void Win()
    {
            textMeshPro.gameObject.SetActive(true);
    }
}
