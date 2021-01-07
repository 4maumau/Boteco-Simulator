using System;
using System.IO.Compression;
using UnityEngine;

public class InteragirArredores : MonoBehaviour
{
    [SerializeField] private float raioAlcance;

    public LayerMask targetMask;
    
    private void Update()
    {
        var interactableObjects = Physics2D.OverlapCircleAll(transform.position, raioAlcance,targetMask);

        for (int i = 0; i < interactableObjects.Length; i++)
        {
            Transform target = interactableObjects[i].transform;
            Debug.Log("Pode interagir com: " + target.gameObject.name);

        }

    }

    private void OnDrawGizmos()
    {
    }
}
