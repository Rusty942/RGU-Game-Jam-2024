using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class LevelSelectAnim: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator animator;
    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        // Find the Animator component attached to the same GameObject
        animator = GetComponent<Animator>();

        // Find the TextMeshPro component attached to the same GameObject
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Called when the mouse enters the UI element
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(animator != null)
        {
            animator.SetBool("Mouseover", true);
        }
        if(textMeshPro != null)
        {
            textMeshPro.color = Color.black;
        }
    }

    // Called when the mouse exits the UI element
    public void OnPointerExit(PointerEventData eventData)
    {
        if(animator != null)
        {
            animator.SetBool("Mouseover", false);
        }
        if(textMeshPro != null)
        {
            textMeshPro.color = new Color(78f/255f, 169f/255f, 0f); // RGB: (78,169,0)
        }
    }
}