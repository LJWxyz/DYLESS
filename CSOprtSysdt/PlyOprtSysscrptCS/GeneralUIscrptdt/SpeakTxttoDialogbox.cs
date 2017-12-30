using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

//public class SpeakTxttoDialogbox: NetworkBehaviour { 
public class SpeakTxttoDialogbox : MonoBehaviour {
    [SerializeField] GameObject PlyDialogBox;
    protected static bool IsDialogBoxOn = false;
    protected static bool PlySpeakMode = true;
    [SerializeField] InputField SpeakInput;
    [SerializeField] Text SpokenTxt=null;
    [SerializeField] GameObject CastInputFieldObj=null;
    [SerializeField] GameObject SpeakInputFieldObj=null;
    void Start () { 
        SpeakInput=GameObject.FindObjectOfType<InputField>();
   
    }

    public void DuringInputSpeak(string WhenInputSetting) {
        HumanPlyMovement.LockPlyMovInput = true;
    }
	
    public void GetSpeakInput(string SpeakInputFieldshowtxt)
    {
        HumanPlyMovement.LockPlyMovInput = false;
        OpenFreakingDialogBox();
        SpokenTxt.text = SpeakInput.text;
        IsDialogBoxOn = true;
        HumanPlyMovement.LockPlyMovInput = true;
        //Textbox=PlaneBG have flexible heightand width; 
        Invoke("OnOffDialogBox", 5.537829654f);

    }

    private void OpenFreakingDialogBox()
    {
        PlyDialogBox.SetActive(true);
    }

    //after 10 sec ,Textbox=SpeakplaneBG,disable /ShownCanvasPublic.Rendermode=ScreenSpaceOverlay.
    protected void OnOffDialogBox(){
        if (SpeakInput.isFocused) { }else
        {
            SpeakInput.text = "";
        }
        if (IsDialogBoxOn) { PlyDialogBox.SetActive(false); SpokenTxt.text = ""; }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            if (PlySpeakMode)
            {PlySpeakMode = false;}else
            { PlySpeakMode = true; }
            ChgPlyrMode();
        }
    }
    void ChgPlyrMode() {
        if (CastInputFieldObj.activeInHierarchy) {
            CastInputFieldObj.SetActive(false);SpeakInputFieldObj.SetActive(true);
        }else {
            CastInputFieldObj.SetActive(true);SpeakInputFieldObj.SetActive(false);
        }

    }

}