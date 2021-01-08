using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mesa : HighlightInteractable
{
    private bool _availableForTower;
    protected TorreDeCerveja torreDeCervejaInstancia;
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
}
