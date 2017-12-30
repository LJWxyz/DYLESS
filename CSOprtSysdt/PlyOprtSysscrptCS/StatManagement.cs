using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class StatManagement {
    private Bardtscrpt GetBardtscrpt=null;
    [SerializeField] private float BaseMaxValue;
[SerializeField] private float CurrentValue;

    private void Awake()
    { UpdateDefaultVal();}

    public float CurrentValueResolve
    { get{ return CurrentValue;
        }
        set{

          this.CurrentValue = Mathf.Clamp(value,0,BaseMaxValue);
            //Wanted to make When Current Value is seted Have it Lerp Over time By a degree of DamageSpeed 
           // CurrentValue = Mathf.Lerp(CurrentValue, CurrentValueResolve, Time.deltaTime * 2);wrong way,it's contininous
            GetBardtscrpt.DTValue = CurrentValue;
            
        }
    }

    public float BaseMaxValueResolve
    {
        get
        {
            return BaseMaxValue;
        }

        set
        {
            BaseMaxValue = value;
            BaseMaxValue=GetBardtscrpt.MaxDtValue ;
            
        }
    }

    public void UpdateDefaultVal(){
      this.BaseMaxValueResolve =BaseMaxValue ;
      this.CurrentValueResolve= CurrentValue ;
    }


}
