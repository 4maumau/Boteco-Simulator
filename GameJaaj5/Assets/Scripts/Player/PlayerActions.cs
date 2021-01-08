using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    private bool holdingTower;
    // Start is called before the first frame update
    void Start()
    {
        holdingTower = false;
    }

    public void SetHoldingTower(bool isHoldingTower)
    {
        holdingTower = isHoldingTower;
    }

    public bool IsHoldingTower() => holdingTower;


    // Update is called once per frame
    void Update()
    {
        
    }
}
