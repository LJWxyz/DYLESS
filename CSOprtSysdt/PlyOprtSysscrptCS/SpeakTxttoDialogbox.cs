using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeakTxttoDialogbox : MonoBehaviour {

    public InputField SpeakInput;
    public Text SpokenTxt;
	void Start () { 
        SpeakInput=GameObject.FindObjectOfType<InputField>();
    }
	
    public void GetSpeakInput(string SpeakInputField){
        SpokenTxt.text=SpeakInput.text;
        SpeakInput.text="";
        //Textbox=PlaneBG have flexible heightand width;   
    }	
    //after 10 sec ,Textbox=SpeakplaneBG,disable /ShownCanvasPublic.Rendermode=ScreenSpaceOverlay.
}