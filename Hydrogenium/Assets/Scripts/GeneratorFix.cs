using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorFix : MonoBehaviour
{
    private Animator animator;
    public AudioSource fix;

    void Start()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();
    }

    public void Win()
    {
        animator.SetBool("Win", true);
        fix.Play();
    }
    
}
