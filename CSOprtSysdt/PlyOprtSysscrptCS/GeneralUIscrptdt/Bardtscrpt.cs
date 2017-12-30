using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bardtscrpt : MonoBehaviour {

    private float FillAmount;
    [SerializeField] private Image Filldt=null;
    [SerializeField] private Text ValueOverMaxVal=null;
    private float SpeedonValChg = 2.13f;

    public float DTValue { set {
            string[] StorewordVal = ValueOverMaxVal.text.Split('/');
            ValueOverMaxVal.text = value+ "/" + StorewordVal[1];
            FillAmount = ValuedtProcessor(value, intmin: 0,intmax:MaxDtValue, OutMin: 0, OutMax: 1); } }

    public float MaxDtValue { get; set; }

    void Start() {
        Filldt.fillAmount = FillAmount;
    }

    void Update() {
        HandleBarDT();
    }

    public void HandleBarDT() {
        if (FillAmount != Filldt.fillAmount){
            Filldt.fillAmount = Mathf.Lerp(Filldt.fillAmount, FillAmount, Time.deltaTime * SpeedonValChg);
        }

    }

    private float ValuedtProcessor(float AmountInput,float intmin,float intmax,float OutMin, float OutMax){
        return (AmountInput - intmin) * (OutMax - OutMin) / (OutMax - OutMin) + OutMin;
    }
   
   
}
