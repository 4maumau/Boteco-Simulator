using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesaBar : HighlightInteractable
{
    private bool _availableForTower;
    private TorreDeCerveja torreDeCervejaInstancia;
    protected override void Start()
    {
        base.Start();
        _availableForTower = true;
    }

    public void SetAvailableForTower(bool available)
    {
        _availableForTower = available;
    }

    public bool IsAvailableForTower() => _availableForTower;

    //Interagir: Coloca a torre de cerveja na mesa
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
        StartCoroutine(TimerToFinishTower());
    }

    IEnumerator TimerToFinishTower()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("Terminaram de comer");
        torreDeCervejaInstancia.SetInUse(false);
    }
    
    //Jogador deve estar segurando uma torre de cerveja e a mesa deve estar vazia.
    protected override bool ConditionToInteract()
    {
        return IsAvailableForTower() && PlayerActionsVar.IsHoldingTower();
    }
}
