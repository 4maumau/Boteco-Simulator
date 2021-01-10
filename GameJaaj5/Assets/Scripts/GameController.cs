using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float moneyMade;
    public float debtToPay;
    
    private int clientsInBar = 0;
    private bool endedSpawning;
    public int currentDay = 0;
    
    [SerializeField] private NpcSpawner _spawner;
    [SerializeField] private List<DayData> levels;

    [SerializeField] private GameObject panelDay;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject gameWin;


    private void Start()
    {
        CaixaRegistradora.Pagamento += Payment;
        NpcBehaviour.CreatedClient += AddClient;
        NpcBehaviour.DeletedClient += ClientLeft;
        NpcSpawner.EndedSpawning += EndSpawning;
        StartNewDay();
    }

    private void Update()
    {
        if (endedSpawning && clientsInBar <= 0)
        {
            EndDay();
        }
    }

    private void EndDay()
    {
        
        
        
            panelDay.SetActive(true);
            print("dia terminou");
        
    }

    private void AddClient()
    {
        clientsInBar++;
    }

    public void StartNewDay()
    {
        debtToPay -= moneyMade;
        if (currentDay == levels.Count)
        {
            if (debtToPay > 0)
            {
                gameOver.SetActive(true);
            }
            else
            {
                gameWin.SetActive(true);
            }
        }
        else
        {
            endedSpawning = false;
            moneyMade = 0;
            panelDay.SetActive(false);
            _spawner.StartSpawning(levels[currentDay++]);
        }
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

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    
}
