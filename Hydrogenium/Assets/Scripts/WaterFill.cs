using UnityEngine;

public class WaterFill : MonoBehaviour
{
    public float maxHeight = 11.8f;
    public float resizeSpeed = 0.1f;

    void Update()
    {
    }

    public void FillUp()
    {
        // Increase height until maxHeight is reached
        if (transform.localScale.y < maxHeight)
        {
            float newHeight = transform.localScale.y + resizeSpeed * Time.deltaTime;
            transform.localScale = new Vector3(transform.localScale.x, newHeight, transform.localScale.z);
        }
    }
}