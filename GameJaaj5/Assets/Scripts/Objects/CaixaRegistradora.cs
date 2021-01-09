using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaRegistradora : HighlightInteractable
{
    private static Queue<NpcBehaviour> clientesAguardando;

    protected override void Start()
    {
        base.Start();
        clientesAguardando = new Queue<NpcBehaviour>();
    }

    public static void WaitInLine(NpcBehaviour npc)
    {
        clientesAguardando.Enqueue(npc);
    }
    
    //Interagir: Recolher dinheiro de clientes que aguardam.
    protected override void Interact()
    {
        SpriteRenderer.material = spriteDefault;
        var clienteAtendido = clientesAguardando.Dequeue();
        clienteAtendido.FinishPayment();
    }

    
    
    //Condição para interagir: Clientes esperando no caixa
    protected override bool ConditionToInteract()
    {
        return clientesAguardando.Count > 0;
    }
}
