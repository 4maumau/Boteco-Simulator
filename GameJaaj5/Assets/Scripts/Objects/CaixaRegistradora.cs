using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaRegistradora : HighlightInteractable
{
    private Queue<int> clientesAguardando;

    protected override void Start()
    {
        base.Start();
        clientesAguardando = new Queue<int>();
    } 
    

    //Interagir: Recolher dinheiro de clientes que aguardam.
    protected override void Interact()
    {
        int clienteAtendido = clientesAguardando.Dequeue();
        throw new System.NotImplementedException();
    }

    
    //Condição para interagir: Clientes esperando no caixa
    protected override bool ConditionToInteract()
    {
        return clientesAguardando.Count > 0;
    }
}
