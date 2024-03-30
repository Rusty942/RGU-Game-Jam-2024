using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityParallax : MonoBehaviour
{
    private float length,startPos;
    public GameObject cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        //Get initial values for the background
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float distance = (cam.transform.position.x* parallaxEffect);
        transform.position = new Vector3(startPos + distance, transform.position.z);

        //Allows the background to infinite scroll
        if(temp > startPos + length){
            startPos += length;               
        }
        else if(temp < startPos - length){
            startPos -= length;
        }
    }
}
