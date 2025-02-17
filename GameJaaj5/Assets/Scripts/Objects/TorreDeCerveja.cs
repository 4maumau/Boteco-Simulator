﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreDeCerveja : HighlightInteractable
{
    private bool _inUse;
    [SerializeField] private bool _isFull;

   
    private TorreAnimator torreAnimator;

    private Mesa mesaQueMeCriou;

    private void Awake()
    {
        base.Start();
        _inUse = false;
        mesaQueMeCriou = null;
        GetComponent<BoxCollider2D>().enabled = true;
        torreAnimator = GetComponent<TorreAnimator>();
    }

    public void SetMesa(Mesa mesa)
    {
        mesaQueMeCriou = mesa;
    }
    
    public void SetInUse(bool inUse)
    {
        _inUse = inUse;
        if(inUse)
            CanInteract = true;
    }

    public void SetFilled(bool isFull)
    {
        //SpriteRenderer.sprite = isFull ? fullTower : emptyTower;
        _isFull = isFull;
    }

    public bool IsFull() => _isFull;
    
    public bool InUse() => _inUse;

    //Interagir: Pega a torre
    protected override void Interact()
    {
        if (mesaQueMeCriou != null)
        {
            mesaQueMeCriou.SetAvailableForTower(true);
            mesaQueMeCriou = null;
        }
        PlayerActionsVar.SetHoldingTower(true);
        CanInteract = false;
        SpriteRenderer.material = spriteDefault;
        transform.position = player.transform.position + (Vector3.up * 1);
        transform.SetParent(player.transform);
        SetInUse(true);
    }

    //Condição para interagir: sobrando torres na mesa de torres Ou em uma mesa sem clientes.
    protected override bool ConditionToInteract()
    {
        return !InUse() && !PlayerActionsVar.IsHoldingTower();
    }

    public void StartDrinking()
    {
        torreAnimator.PlayDrinking();
    }

    public void PlayRefilAnimation()
    {
        torreAnimator.animator.Play("Refill Tree");
    }

    public void UpdateAnimation (float refilAmount)
    {
        torreAnimator.animator.SetFloat("RefilAmount", refilAmount);
    }
}
