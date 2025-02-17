﻿using System;
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
    
    private void UpdateSpacesEntrada()
    {
        var array = freeSpaces.ToArray();
        for (int i = 0; i < array.Length; i++)
        {
            array[i].MoveInLine(gameObject.transform.GetChild(i).GetComponent<Transform>());
        }
    }
    
    private void UpdateSpacesPagamento()
    {
        var array = freeSpaces.ToArray();
        for (int i = 0; i < array.Length; i++)
        {
            array[i].MoveInPaymentLine(gameObject.transform.GetChild(i).GetComponent<Transform>());
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
            UpdateSpacesEntrada();
        }
        else
        {
            mesaLiberada.EmptyForClients = true;
        }
    }

    public void PagamentoRealizado()
    {
        if (freeSpaces.Count <= 0) return;
        freeSpaces.Dequeue();
        UpdateSpacesPagamento();
    }


}
