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
    private int currentDay = 0;
    
    [SerializeField] private NpcSpawner _spawner;
    [SerializeField] private List<DayData> levels;


    private void Start()
    {
        CaixaRegistradora.Pagamento += Payment;
        NpcBehaviour.CreatedClient += AddClient;
        NpcBehaviour.DeletedClient += ClientLeft;
        NpcSpawner.EndedSpawning += EndSpawning;
        StartNewDay(currentDay++);
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

    public void StartNewDay(int day)
    {
        moneyMade = 0;
        _spawner.StartSpawning(levels[day]);
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
