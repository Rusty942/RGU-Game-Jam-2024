using UnityEngine;

public class OxygenItem : MonoBehaviour
{
    public float bobSpeed = 1f; // Speed of the bobbing motion
    public float bobHeight = 0.5f; // Maximum height of bobbing motion

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new position based on a sine wave
        float newY = startPosition.y + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}