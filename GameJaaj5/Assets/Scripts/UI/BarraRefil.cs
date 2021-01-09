using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraRefil : MonoBehaviour
{
    MesaRefill mesaRefill;
    GameObject barraRefil;
    [SerializeField] private Image barImage;

    void Start()
    {
        mesaRefill = FindObjectOfType<MesaRefill>();
        barraRefil = transform.GetChild(0).gameObject;
    }
    
   
    void Update()
    {
        barraRefil.SetActive(mesaRefill._refilling);
        barImage.fillAmount = mesaRefill._refilAmount/100;

    }
}
