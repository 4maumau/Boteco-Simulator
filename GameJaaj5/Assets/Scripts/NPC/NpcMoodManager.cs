using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMoodManager : MonoBehaviour
{
    public enum Mood { Mad, Normal, Happy};
    public Mood currentMood;

    private NpcBehaviour npc;
    private NpcAnimator animator;

    public float waitingTimer = 60f;
    
    public bool running;
    private void Start()
    {
        npc = GetComponent<NpcBehaviour>();
        animator = GetComponent<NpcAnimator>();
    }

    private void Update()
    {
        if(npc.currentState == NpcBehaviour.State.Waiting || npc.currentState == NpcBehaviour.State.WaitingForDrink)
        {
            waitingTimer -= Time.deltaTime;
        }
        if(running) waitingTimer -= Time.deltaTime;

        SetMood();
        
    }

    void SetMood()
    {
        if (waitingTimer > 40f)
        {
            currentMood = Mood.Happy;
        }
        else if (waitingTimer > 20f)
        {
            currentMood = Mood.Normal;
        }
        else currentMood = Mood.Mad;
    }

    void FeedbackReaction()
    {
        switch (currentMood)
        {

            case Mood.Happy:
                animator.PlayReaction("HappyReaction");
                break;
            case Mood.Normal:
                animator.PlayReaction("NormalReaction");
                break;
            case Mood.Mad:
                animator.PlayReaction("MadReaction");
                break;
            default:
                break;
        }
    }
}
