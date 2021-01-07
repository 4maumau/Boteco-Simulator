using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreDeCerveja : HighlightInteractable
{
    protected override void Interact()
    {
        _canInteract = false;
        _spriteRenderer.material = spriteDefault;
        GetComponent<BoxCollider2D>().enabled = false;
        transform.position = player.transform.position + (Vector3.up * 1);
        transform.SetParent(player.transform);
    }
}
