using UnityEngine;

public class WaterFill : MonoBehaviour
{
    public float originalHeight = 5f; // assuming the original height of the cube is 5
    public float maxHeight = 11.8f;
    public float fillSpeed = 0.1f;
    public float shrinkSpeed = 0.1f;

    private bool isFilling = true;


    void Update()
    {
        if (isFilling)
        {
            FillUp();
        }
        else
        {
            ShrinkDown();
        }
    }

    public void FillUp()
    {
        // Increase height until maxHeight is reached
        if (transform.localScale.y < maxHeight)
        {
            float newHeight = transform.localScale.y + fillSpeed * Time.deltaTime;
            transform.localScale = new Vector3(transform.localScale.x, newHeight, transform.localScale.z);
        }
        else
        {
            isFilling = false; // stop filling and start shrinking
        }
    }

    public void ShrinkDown()
    {
        // Decrease height until originalHeight is reached
        if (transform.localScale.y > originalHeight)
        {
            float newHeight = transform.localScale.y - shrinkSpeed * Time.deltaTime;
            transform.localScale = new Vector3(transform.localScale.x, newHeight, transform.localScale.z);
        }
    }
}