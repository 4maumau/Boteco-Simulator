using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPopup : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    [SerializeField] private float destroyTime = 3f;
    
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.sortingLayerName = "UI";
        print("sorting layer:" + meshRenderer.sortingLayerName);
        //Destroy(gameObject, destroyTime);
    }
}
