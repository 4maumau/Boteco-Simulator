using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesaRefill : Mesa
{
    
    protected override void Interact()
    {
        SpriteRenderer.material = spriteDefault;
        SetAvailableForTower(false);
        PlayerActionsVar.SetHoldingTower(false);
        torreDeCervejaInstancia = player.GetComponentInChildren<TorreDeCerveja>();
        Debug.Log(torreDeCervejaInstancia.gameObject.name);
        torreDeCervejaInstancia.gameObject.transform.position = transform.position;
        torreDeCervejaInstancia.gameObject.transform.SetParent(null);
        torreDeCervejaInstancia.SetMesa(this);
        StartCoroutine(RefillTimer());
    }


    IEnumerator RefillTimer()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("Terminou de encher");
        torreDeCervejaInstancia.SetFilled(true);
        torreDeCervejaInstancia.SetInUse(false);
    }
    
    protected override bool ConditionToInteract()
    {
        return PlayerActionsVar.IsHoldingTower() && !player.GetComponentInChildren<TorreDeCerveja>().IsFull() && IsAvailableForTower();
    }
}
