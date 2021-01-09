using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesaChopholder : Mesa
{

    protected override void Interact()
    {
        CanInteract = false;
        SpriteRenderer.material = spriteDefault;
        SetAvailableForTower(false);
        PlayerActionsVar.SetHoldingTower(false);
        torreDeCervejaInstancia = player.GetComponentInChildren<TorreDeCerveja>();
        torreDeCervejaInstancia.gameObject.transform.position = transform.position + Vector3.up * 0.5f;
        torreDeCervejaInstancia.gameObject.transform.SetParent(null);
        torreDeCervejaInstancia.SetMesa(this);
        torreDeCervejaInstancia.SetInUse(false);
    }

    protected override bool ConditionToInteract()
    {
        return PlayerActionsVar.IsHoldingTower() && IsAvailableForTower();
    }
}
