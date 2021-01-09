using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NpcSpawner : MonoBehaviour
{

    [SerializeField] private GameObject npcPrefab;
    [SerializeField] private Fila fila;
    [SerializeField] private Fila filaPagamento;
    [SerializeField] private Transform caixa;

    public static event Action EndedSpawning;
    
    private List<int> _spawnDelayDays;
    
    
    public void StartSpawning(DayData day)
    {
        _spawnDelayDays = day.delayBetweenSpawn;
        StartCoroutine(Spawner());
    }

  

    IEnumerator Spawner()
    {
        var count = 0;
        while (_spawnDelayDays.Count >  count)
        {
            yield return new WaitForSeconds(_spawnDelayDays[count++]);
            if (fila.Count() >= 4) continue;

            var npc = Instantiate(npcPrefab, transform.position, Quaternion.identity);
            var behaviour = npc.GetComponent<NpcBehaviour>();
            behaviour.filaEntrada = fila;
            behaviour.filaPagamento = filaPagamento;
            behaviour.caixa = caixa;
            behaviour.exit = transform;
        }
        EndedSpawning?.Invoke();
    }
}
