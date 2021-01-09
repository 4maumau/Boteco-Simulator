using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreAnimator : MonoBehaviour
{
    public Animator animator;
    public Sprite test;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        animator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    private void Update()
    {
        spriteRenderer.sprite = test;
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
