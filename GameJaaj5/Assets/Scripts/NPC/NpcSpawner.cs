using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NpcSpawner : MonoBehaviour
{

    [SerializeField] private GameObject npcPrefab;
    [SerializeField] private Fila fila;
    [SerializeField] private Transform caixa;
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {

        while (true)
        {
            yield return new WaitForSeconds(5);
            if (fila.Count() >= 4) continue;

            var npc = Instantiate(npcPrefab, transform.position, Quaternion.identity);
            var behaviour = npc.GetComponent<NpcBehaviour>();
            behaviour.fila = fila;
            behaviour.caixa = caixa;
            behaviour.exit = transform;
            
        }
        
    }
}
