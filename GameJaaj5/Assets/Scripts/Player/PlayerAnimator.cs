using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]private PlayerMovement playerMovement;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        Vector2 moveDirection = playerMovement.moveInput;
        animator.SetFloat("FaceX", moveDirection.x);
        animator.SetFloat("FaceY", moveDirection.y);
        if (moveDirection != Vector2.zero)
        {
            animator.Play("Walk");
        }
        else animator.Play("Idle");
    }

}
