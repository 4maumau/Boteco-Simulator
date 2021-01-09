using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MesaRefill : Mesa
{

    private const float FullRefilGoal = 100;
    private float _refilAmount = 0;
    private float _refilStep = 0.6f;
    private bool _refilling;
    private bool _isNear;
    protected override void Interact()
    {
        CanInteract = false;
        SpriteRenderer.material = spriteDefault;
        SetAvailableForTower(false);
        PlayerActionsVar.SetHoldingTower(false);
        torreDeCervejaInstancia = player.GetComponentInChildren<TorreDeCerveja>();
        torreDeCervejaInstancia.gameObject.transform.position = transform.position;
        torreDeCervejaInstancia.gameObject.transform.SetParent(null);
        torreDeCervejaInstancia.SetMesa(this);

        torreDeCervejaInstancia.PlayRefilAnimation();
        _refilling = true;
        _refilAmount = 0;

    }

    protected override void OnTriggerStay2D(Collider2D other)
    {
        _isNear = true;
        base.OnTriggerStay2D(other);
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        _isNear = false;
        base.OnTriggerExit2D(other);
    }


    protected override void Update()
    {
        base.Update();

        if (!_refilling) return;
        
        if (Keyboard.current.spaceKey.isPressed && _isNear)
        {
            _refilAmount += _refilStep;
        }
        
        if (_refilAmount < 0)
            _refilAmount = 0;
            
        if(_refilAmount >= FullRefilGoal)
            FinishRefilling();

        torreDeCervejaInstancia.UpdateAnimation(_refilAmount);

    }

    private void FinishRefilling()
    {
        _refilling = false;
        Debug.Log("Terminou de encher");
        torreDeCervejaInstancia.SetFilled(true);
        torreDeCervejaInstancia.SetInUse(false);
    }


    protected override bool ConditionToInteract()
    {
        return PlayerActionsVar.IsHoldingTower() && !player.GetComponentInChildren<TorreDeCerveja>().IsFull() && IsAvailableForTower();
    }
}
