using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
    
    private void UpdateSpaces()
    {
        var array = freeSpaces.ToArray();
        Debug.Log(array.Length);
        for (int i = 0; i < array.Length; i++)
        {
            Debug.Log(gameObject.transform.GetChild(i).name);
            array[i].MoveInLine(gameObject.transform.GetChild(i).GetComponent<Transform>());
        }
    }

    public int Count()
    {
        return freeSpaces.Count;
    }

    public void LiberouMesa(MesaBar mesaLiberada)
    {
        if (freeSpaces.Count > 0)
        {
            freeSpaces.Dequeue().OffTheLine(mesaLiberada);
            UpdateSpaces();
        }
        else
        {
            mesaLiberada.EmptyForClients = true;
        }
        
        
    }


}
