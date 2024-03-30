using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SequentialTextMeshProFade : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro1;
    public TextMeshProUGUI textMeshPro2;
    public TextMeshProUGUI textMeshPro3;
    public TextMeshProUGUI textMeshPro4;

    public float fadeInDuration = 1.0f;
    public float fadeOutDuration = 1.0f;
    public float displayDuration = 5.0f;
    public float delayBetweenTexts = 1.0f;

    private bool spacePressed = false;

    private void Start()
    {
        // Initially hide all TextMeshPro objects
        textMeshPro1.gameObject.SetActive(false);
        textMeshPro2.gameObject.SetActive(false);
        textMeshPro3.gameObject.SetActive(false);
        textMeshPro4.gameObject.SetActive(false);

        StartCoroutine(SequentialFadeRoutine());
    }

    private void Update()
    {
        // Check for spacebar input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Set the spacePressed flag to true
            spacePressed = true;
        }
    }

    private IEnumerator SequentialFadeRoutine()
    {
        yield return FadeInAndOut(textMeshPro1);
        yield return new WaitForSeconds(delayBetweenTexts);
        yield return FadeInAndOut(textMeshPro2);
        yield return new WaitForSeconds(delayBetweenTexts);
        yield return FadeInAndOut(textMeshPro3);
        yield return new WaitForSeconds(delayBetweenTexts);
        yield return FadeInAndOut(textMeshPro4);

        // Load next scene after the last fade is completed or if space is pressed
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator FadeInAndOut(TextMeshProUGUI textMeshPro)
    {
        textMeshPro.gameObject.SetActive(true);

        // Fade In
        float timer = 0f;
        while (timer < fadeInDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeInDuration);
            textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, alpha);

            // Check if space is pressed
            if (spacePressed)
            {
                LoadNextScene();
                yield break; // Exit the coroutine early
            }

            yield return null;
        }

        yield return new WaitForSeconds(displayDuration);

        // Fade Out
        timer = 0f;
        while (timer < fadeOutDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeOutDuration);
            textMeshPro.color = new Color(textMeshPro.color.r, textMeshPro.color.g, textMeshPro.color.b, alpha);

            // Check if space is pressed
            if (spacePressed)
            {
                LoadNextScene();
                yield break; // Exit the coroutine early
            }

            yield return null;
        }

        textMeshPro.gameObject.SetActive(false);
    }
}