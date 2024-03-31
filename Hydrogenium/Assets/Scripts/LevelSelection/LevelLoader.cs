using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelLoader: MonoBehaviour, IPointerClickHandler
{
    public string levelName; // Name of the scene to load

    // Called when the UI element is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        LoadScene();
    }



    // Function to load the scene
    private void LoadScene()
    {
        SceneManager.LoadScene(levelName);
    }
}