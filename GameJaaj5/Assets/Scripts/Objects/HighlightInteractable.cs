using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class HighlightInteractable : MonoBehaviour
{
    protected SpriteRenderer SpriteRenderer;
    protected bool CanInteract;
    protected PlayerActions PlayerActionsVar;
    
    [SerializeField] private Material interactableMaterial;
    [SerializeField] protected Material spriteDefault;
    [SerializeField] protected GameObject player;
    
    protected virtual void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        CanInteract = false;
        PlayerActionsVar = player.GetComponent<PlayerActions>();
    }

    protected virtual void Update()
    {
        if (CanInteract && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Interact();
        }
    }

    protected abstract void Interact();
    protected abstract bool ConditionToInteract();

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || !ConditionToInteract()) return;

        player = other.gameObject;
        SpriteRenderer.material = interactableMaterial;
        CanInteract = true;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        SpriteRenderer.material = spriteDefault;
        CanInteract = false;
    }
    
}
