using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreAnimator : MonoBehaviour
{
    Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayDrinking()
    {
        animator.Play("Drinking");
    }
    public void PlayRefill()
    {
        animator.Play("Filling");
    }
    
}
