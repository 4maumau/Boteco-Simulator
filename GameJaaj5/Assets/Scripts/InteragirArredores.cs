using System;
using System.IO.Compression;
using UnityEngine;

public class InteragirArredores : MonoBehaviour
{
    [SerializeField] private float raioAlcance;

    private void Update()
    {
        var raycastHit2D = Physics2D.CircleCast(transform.position, raioAlcance, Vector2.up);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position,raioAlcance);
    }
}
