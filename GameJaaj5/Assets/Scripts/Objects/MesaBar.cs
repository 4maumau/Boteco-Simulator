using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesaBar : Mesa
{
    private bool _emptyForClients = true;
    private bool _waitingDrink = false;
    
    public Action RecebeuCerveja; 
    
    private void Awake()
    {
        NpcBehaviour.TableInicialization += AddTableToList;
    }

    private void AddTableToList(List<MesaBar> lista)
    {
        lista.Add(this);
    }

    public bool EmptyForClients
    {
        get => _emptyForClients;
        set => _emptyForClients = value;
    }

    public bool WaitingDrink
    {
        get => _waitingDrink;
        set => _waitingDrink = value;
    }

    //Interagir: Coloca a torre de cerveja na mesa
    protected override void Interact()
    {
        SpriteRenderer.material = spriteDefault;
        SetAvailableForTower(false);
        PlayerActionsVar.SetHoldingTower(false);
        torreDeCervejaInstancia = player.GetComponentInChildren<TorreDeCerveja>();
        Debug.Log(torreDeCervejaInstancia.gameObject.name);
        torreDeCervejaInstancia.gameObject.transform.position = transform.position + Vector3.up * 0.5f;
        torreDeCervejaInstancia.gameObject.transform.SetParent(null);
        torreDeCervejaInstancia.SetMesa(this);
        RecebeuCerveja?.Invoke();
    }

    public void FinishedDrinking()
    {
        Debug.Log("Terminaram de beber");
        WaitingDrink = false;
        torreDeCervejaInstancia.SetInUse(false);
        torreDeCervejaInstancia.SetFilled(false);
    }
    
    //Jogador deve estar segurando uma torre de cerveja e a mesa deve estar vazia.
    protected override bool ConditionToInteract()
    {
        return IsAvailableForTower() && PlayerActionsVar.IsHoldingTower() &&
               player.GetComponentInChildren<TorreDeCerveja>().IsFull() && WaitingDrink;
    }
}
