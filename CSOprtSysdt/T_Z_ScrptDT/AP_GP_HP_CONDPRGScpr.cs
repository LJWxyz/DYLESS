using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AP_GP_HP_CONDPRGScpr : MonoBehaviour {
    public string[] APnew_CondStrng =new string[4]{"Create an Arithmetic Progression with a resultant of 50."
        ,"Create an Arithmetic Progression with a resultant of 30."
        ,"Create an Arithmetic Progression with resultant bigger than 20."
        ,"Create an Arithmetic Progression with the first term as 45."};
    public string[] APMedium_D1CondStrng = new string[3]{"Create an A.P. with a result of -97.5,and common difference must be +ve."
        ,"Create an A.P. with a resultant of -85.5,and a common difference of 5."
        ,"Create an A.P. with a resultant of -35,and a common difference of 20."
    };
    public string[] GPnew_CondStrng =new string[]{"",""};
    public Text APnew_CondText;
    public Text APmedium_D1CondText;
    public Text GPnew_CondText;
    public Text seriesIntroCondText;
    public InputField APnew_PlyInput;
    public InputField GPnew_PlyInput;
    public InputField SeriesIntroPlyInput;

    void StrtAPnew_PRGCondFunc () {
        Random.seed=(int)System.DateTime.Now.Ticks;
        int APnew_CondRandomIndex =Random.Range(1,4);
        APnew_CondText.text= APnew_CondStrng[APnew_CondRandomIndex];
	}

    void StrtAPmedium_D1PRDCondFunc () {
        Random.seed=(int)System.DateTime.UtcNow.Ticks;
        int APmedium_CondRandomIndex =Random.Range(1,3);
        APnew_CondText.text= APnew_CondStrng[APmedium_CondRandomIndex];
    }
	void Update () {
		
	}
}
