using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPopup : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.sortingLayerName = "UI";
        print("sorting layer:" + meshRenderer.sortingLayerName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
