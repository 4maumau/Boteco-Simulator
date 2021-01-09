using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAnimator : MonoBehaviour
{
    Animator animator;
    NpcBehaviour npc;

    public Animator reactionsAnimator;
    private GameObject reactionsObj;

    private void Start()
    {
        animator = GetComponent<Animator>();
        reactionsObj = transform.GetChild(0).gameObject;
        npc = GetComponentInParent<NpcBehaviour>();
    }

    private void Update()
    {
       switch (npc.currentState)
        {
            case NpcBehaviour.State.Walking:
                animator.Play("Walk Tree");
                animator.SetFloat("FaceX", npc.direction.x);
                animator.SetFloat("FaceY", npc.direction.y);
                break;

            case NpcBehaviour.State.Sitting:
                animator.Play("Sitting Tree");
                break;

            case NpcBehaviour.State.WaitingForDrink:
                animator.Play("Sitting Tree");
                break;

            case NpcBehaviour.State.Drinking:
                animator.Play("Sitting Tree");
                break;
            case NpcBehaviour.State.Waiting:
                animator.Play("Idle Tree");
                break;

            default:
                animator.Play("Idle Tree");
                break;
        }

    }

    public void PlayReaction(string reaction)
    {
        reactionsObj.SetActive(true);
        reactionsAnimator.Play(reaction, -1, 0f);
    }

    public void StopReaction()
    {
        reactionsObj.SetActive(false);
    }
}
