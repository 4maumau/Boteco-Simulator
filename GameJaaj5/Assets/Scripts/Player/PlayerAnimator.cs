using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]private PlayerMovement playerMovement;
    private Animator animator;
    private PlayerActions playerActions;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerActions = GetComponentInParent<PlayerActions>();
    }

    private void Update()
    {
        Vector2 moveDirection = playerMovement.moveInput;
        animator.SetFloat("FaceX", moveDirection.x);
        animator.SetFloat("FaceY", moveDirection.y);

        if (moveDirection != Vector2.zero)
        {
            if (playerActions.holdingTower) animator.Play("Item Walk Tree");
            else animator.Play("Walk");
        }
        else
        {
            if (playerActions.holdingTower) animator.Play("Item Idle Tree");
            else animator.Play("Idle");
        }

        
    }

}
