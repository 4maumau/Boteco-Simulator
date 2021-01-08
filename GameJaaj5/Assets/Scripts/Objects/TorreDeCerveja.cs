using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreDeCerveja : HighlightInteractable
{
    private bool _inUse;

    private MesaBar mesaQueMeCriou;

    private void Awake()
    {
        base.Start();
        _inUse = false;
        mesaQueMeCriou = null;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public void SetMesa(MesaBar mesaBar)
    {
        mesaQueMeCriou = mesaBar;
    }
    

    public void SetInUse(bool inUse)
    {
        _inUse = inUse;
    }

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
}
