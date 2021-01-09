using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fila : MonoBehaviour
{
    private Queue<NpcBehaviour> freeSpaces;

    private void Start()
    {
        freeSpaces = new Queue<NpcBehaviour>();
    }

    public Transform EnqueueClient(NpcBehaviour client)
    {
        freeSpaces.Enqueue(client);
        return gameObject.transform.GetChild(freeSpaces.Count - 1).GetComponent<Transform>();
    }

    public void DequeueClient()
    {
        freeSpaces.Dequeue().OffTheLine();
        UpdateSpaces();
    }

    private void UpdateSpaces()
    {
        var count = 0;
        foreach (var client in freeSpaces)
        {
            client.MoveInLine(gameObject.transform.GetChild(count++).GetComponent<Transform>());
        }
    }


}
