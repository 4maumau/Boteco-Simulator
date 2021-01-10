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
    public TextMeshProUGUI diasRestantesTXT;

    void Start()
    {
       
    }
    private void OnEnable()
    {
        GetComponent<Animator>().Play("NovoDia", -1, 0);
        moneyEarnedTXT.SetText("Ganhou: {}", gameController.moneyMade);
        deptTXT.SetText("Dívida com o Agiota: {}", gameController.debtToPay - gameController.moneyMade);
        diaTXT.SetText("DIA {}", gameController.currentDay);
        diasRestantesTXT.SetText("Dias Restantes: {}", gameController.levels.Count - gameController.currentDay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
