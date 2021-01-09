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

    private bool _isSpawning;
    
    public void StartSpawning()
    {
        _isSpawning = true;
        StartCoroutine(Spawner());
    }

    public void StopSpawning()
    {
        _isSpawning = false;
    }

    IEnumerator Spawner()
    {
        while (_isSpawning)
        {
            yield return new WaitForSeconds(5);
            if (fila.Count() >= 4) continue;

            var npc = Instantiate(npcPrefab, transform.position, Quaternion.identity);
            var behaviour = npc.GetComponent<NpcBehaviour>();
            behaviour.filaEntrada = fila;
            behaviour.filaPagamento = filaPagamento;
            behaviour.caixa = caixa;
            behaviour.exit = transform;
        }
    }
}
