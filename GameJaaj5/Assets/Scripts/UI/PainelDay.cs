using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PainelDay : MonoBehaviour
{
    public GameController gameController;
    
    [Header("Texts")]
    public TextMeshProUGUI diaTXT;
    public TextMeshProUGUI moneyEarnedTXT;
    public TextMeshProUGUI deptTXT;

    void Start()
    {
       
    }
    private void OnEnable()
    {
        GetComponent<Animator>().Play("NovoDia", -1, 0);
        moneyEarnedTXT.SetText("Ganhou: {}", gameController.moneyMade);
        deptTXT.SetText("Dívida Restante: {}", gameController.debtToPay - gameController.moneyMade);
        diaTXT.SetText("DIA {}", gameController.currentDay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
