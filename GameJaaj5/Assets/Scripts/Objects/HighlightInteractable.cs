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

    private static bool _canOthersInteract;
    
    [SerializeField] private Material interactableMaterial;
    [SerializeField] protected Material spriteDefault;
    [SerializeField] protected GameObject player;
    
    protected virtual void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        CanInteract = false;
        PlayerActionsVar = player.GetComponent<PlayerActions>();
        _canOthersInteract = true;
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

    protected virtual void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || !ConditionToInteract() || !_canOthersInteract) return;

        player = other.gameObject;
        SpriteRenderer.material = interactableMaterial;
        CanInteract = true;
        _canOthersInteract = false;
    }
    
    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        SpriteRenderer.material = spriteDefault;
        CanInteract = false;
        _canOthersInteract = true;

    }
    
}
