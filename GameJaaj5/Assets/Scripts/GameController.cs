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
    [SerializeField] private int tempoDeJogoSegundos = 10;


    private void Start()
    {
        CaixaRegistradora.Pagamento += Payment;
        StartCoroutine(LevelTimer());
        NpcBehaviour.CreatedClient += AddClient;
        NpcBehaviour.DeletedClient += ClientLeft;
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

    IEnumerator LevelTimer()
    {
        _spawner.StartSpawning();
        yield return new WaitForSeconds(tempoDeJogoSegundos);
        _spawner.StopSpawning();
        endedSpawning = true;
    }
    
    
}
