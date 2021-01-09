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

    [SerializeField] AudioClip[] audioClips;
    AudioSource audioSource;

    private void Start()
    {
        npc = GetComponent<NpcBehaviour>();
        animator = GetComponentInChildren<NpcAnimator>();

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(npc.currentState == NpcBehaviour.State.Waiting || npc.currentState == NpcBehaviour.State.WaitingForDrink)
        {
            waitingTimer -= Time.deltaTime;
        }

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

    public void FeedbackReaction()
    {
        switch (currentMood)
        {

            case Mood.Happy:
                animator.PlayReaction("HappyReaction");
                audioSource.clip = audioClips[0];
                audioSource.Play();
                break;
            case Mood.Normal:
                animator.PlayReaction("NormalReaction");
                audioSource.clip = audioClips[1];
                audioSource.Play();
                break;
            case Mood.Mad:
                animator.PlayReaction("MadReaction");
                audioSource.clip = audioClips[2];
                audioSource.Play();
                break;
            default:
                break;
        }
    }
}