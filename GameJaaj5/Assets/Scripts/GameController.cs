using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private float moneyMade;
    private int clientsInBar = 0;
    private float debtToPay;
    private bool endedSpawning;

    [SerializeField] private NpcSpawner _spawner;


    private void Start()
    {
        CaixaRegistradora.Pagamento += Payment;
        _spawner.StartSpawning();
        NpcBehaviour.CreatedClient += AddClient;
        NpcBehaviour.DeletedClient += ClientLeft;
        NpcSpawner.EndedSpawning += EndSpawning;
    }

    private void Update()
    {
        if (endedSpawning && clientsInBar <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        
    }

    private void AddClient()
    {
        clientsInBar++;
    }

    private void ClientLeft()
    {
        clientsInBar--;
    }

    private void Payment(float amount)
    {
        moneyMade += amount;
    }

    private void EndSpawning()
    {
        endedSpawning = true;
    }
    
    
}
