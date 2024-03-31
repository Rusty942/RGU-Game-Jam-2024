using UnityEngine;
using TMPro;
using System.Collections;

public class TutorialInstructions : MonoBehaviour
{
    public TextMeshProUGUI firstTextMeshPro;
    public TextMeshProUGUI secondTextMeshPro;

    private float fadeInTime = 2f;
    private float fadeOutTime = 2f;
    private float displayTime = 1f; // Reduced display time for the first text
    private float startDelay = 1f;

    private void Start()
    {
        // Set initial transparency to zero for both text objects
        firstTextMeshPro.alpha = 0f;
        secondTextMeshPro.alpha = 0f;

        // Start the fading coroutine for the first text
        StartCoroutine(FirstTextFadeInOut());
    }

    private IEnumerator FirstTextFadeInOut()
    {
        yield return new WaitForSeconds(startDelay);

        // Fade in the first text
        float timer = 0f;
        while (timer < fadeInTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeInTime);
            firstTextMeshPro.alpha = alpha;
            timer += Time.deltaTime;
            yield return null;
        }

        // Wait for the first text to be displayed
        yield return new WaitForSeconds(displayTime);

        // Fade out the first text
        timer = 0f;
        while (timer < fadeOutTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeOutTime);
            firstTextMeshPro.alpha = alpha;
            timer += Time.deltaTime;
            yield return null;
        }

        // Ensure final transparency of the first text is exactly zero
        firstTextMeshPro.alpha = 0f;

        // Start fading in the second text
        StartCoroutine(SecondTextFadeInOut());
    }

    private IEnumerator SecondTextFadeInOut()
    {
        // Wait for a short delay before fading in the second text
        yield return new WaitForSeconds(0.5f); // Adjust this delay as needed

        // Fade in the second text
        float timer = 0f;
        while (timer < fadeInTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeInTime);
            secondTextMeshPro.alpha = alpha;
            timer += Time.deltaTime;
            yield return null;
        }

        // Wait for the second text to be displayed
        yield return new WaitForSeconds(displayTime);

        // Fade out the second text
        timer = 0f;
        while (timer < fadeOutTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeOutTime);
            secondTextMeshPro.alpha = alpha;
            timer += Time.deltaTime;
            yield return null;
        }

        // Ensure final transparency of the second text is exactly zero
        secondTextMeshPro.alpha = 0f;
    }
}