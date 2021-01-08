using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesaBar : HighlightInteractable
{
    private bool _availableForTower;
    [SerializeField] private GameObject torreDeCervejaPrefab;
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
        Destroy(player.GetComponentInChildren<TorreDeCerveja>().gameObject);
        PlayerActionsVar.SetHoldingTower(false);
        torreDeCervejaInstancia = Instantiate(torreDeCervejaPrefab,transform.position, Quaternion.identity).GetComponent<TorreDeCerveja>();
        torreDeCervejaInstancia.SetInUse(true);
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
