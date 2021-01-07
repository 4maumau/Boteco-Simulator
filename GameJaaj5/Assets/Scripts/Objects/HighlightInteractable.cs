using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class HighlightInteractable : MonoBehaviour
{
    protected SpriteRenderer _spriteRenderer;
    protected bool _canInteract;
    
    [SerializeField] private Material interactableMaterial;
    [SerializeField] protected Material spriteDefault;
    [SerializeField] protected GameObject player;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _canInteract = false;
    }

    private void Update()
    {
        if (_canInteract && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Interact();
        }
    }

    protected abstract void Interact();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        player = other.gameObject;
        _spriteRenderer.material = interactableMaterial;
        _canInteract = true;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        _spriteRenderer.material = spriteDefault;
        _canInteract = false;
    }
    
}
