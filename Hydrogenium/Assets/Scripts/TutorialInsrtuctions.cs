using UnityEngine;
using TMPro;
using System.Collections;

public class TutorialInsrtuctions : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    private float fadeInTime = 2f;
    private float fadeOutTime = 2f;
    private float startDelay = 1f;

    private void Start()
    {
        // Set initial transparency to zero
        textMeshPro.alpha = 0f;

        // Start the fading coroutine
        StartCoroutine(FadeInOut());
    }

    private IEnumerator FadeInOut()
    {
        yield return new WaitForSeconds(startDelay);

        // Fade in
        float timer = 0f;
        while (timer < fadeInTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeInTime);
            textMeshPro.alpha = alpha;
            timer += Time.deltaTime;
            yield return null;
        }

        // Wait for 3 seconds
        yield return new WaitForSeconds(2f);

        // Fade out
        timer = 0f;
        while (timer < fadeOutTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeOutTime);
            textMeshPro.alpha = alpha;
            timer += Time.deltaTime;
            yield return null;
        }

        // Ensure final transparency is exactly zero
        textMeshPro.alpha = 0f;
    }
}
