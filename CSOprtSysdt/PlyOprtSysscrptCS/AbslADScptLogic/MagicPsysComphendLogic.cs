using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.Networking;
[RequireComponent(typeof(ParticleSystem))]
//public class MagicPsysComphendLogic : NetworkBehaviour {
public class MagicPsysComphendLogic : MonoBehaviour {
    //Declaration of MagicPsysLogicComprehendBycompsysrealtimeResolving
    string[] LightningCastKeywrd =
       {"Golden lightning","Golden Lightning","Lightning","Pierce","pierce","split","Split","Thunder","thunder","Slash","slash","slice","Slice","gush forth","Discharge","discharge"};
    string[] WindCastKeyword =
        {"Pierce","pierce","split","Split","Slash","slash","slice","Slice","gush forth"};
    string[] FireCastKeyword =
        {"Burn","Inferno","Pierce","pierce","split","Split","Slash","slash","slice","Slice","gush forth","erupt"};
    string[] WaterCastKeyword =
        {"Slash","slash","slice","Slice","","gush forth","erupt"};
    string[] EarthCastKeyword =
        {"","Slash","slash","slice","Slice","","gush forth","erupt","rupture","Rupture","Disintergrate"};
    string[] IceCastKeyword =
        {"blizzard","Silver","Slash","slash","slice","Slice","","gush forth","erupt"};
    string[] LightCastKeyword =
        {"White Magic","white magic","Slash","slash","slice","Slice"};
    string[] SPeffectKeyword =
    {"Grant,StartDelay=false","Rend asunder,break through lim~","I am The XYZ"};
    string[] RBqualityKeyword = { "Heavy", "Solid", };
    string[] QuantitySingleDigitMultply = { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
    string[] Quantity1000Multiply = { };
    string[] SingCastKeywordnonPart = { };
    //common var declarartion
    public InputField Cast_SpellInput = null;
    [SerializeField] Text PlyCastSysAcknowledgedText = null;
    [SerializeField] Text PlyCastFinalActivationText = null;
    [SerializeField] ParticleSystem PlyPSysMainEffct = null;
    [SerializeField] ParticleSystem.Particle PlyChoosenSys_Particles;
    [SerializeField] ParticleSystem.MainModule PlyPSYSMainMod;
    [SerializeField] float AutoClearFinalCastTxt = 1f;
    [SerializeField] float WorldCastProcessTime = 0.1f;
    //exagerrate effect,effect by element,*subeffect
    [SerializeField] ParticleSystem CstRecognisedActPSys = null;
    [SerializeField] float ManipulationPowerFromPlyr;



    void Start() { }
    public void GetCastActivationInput(string CastActivationInputField) {
        PlyCastFinalActivationText.text = Cast_SpellInput.text;
        ResetTxtforCastingAct();
    }
    public void GetCastInput(string CastProcessInputField) {
        PlyCastSysAcknowledgedText.text = Cast_SpellInput.text;
        ResetTxtforCastProcess();
    }

    //need to make case insensitive
    void Update() {
        //if(isLocalPlayer&&PlyManipulationPower,from the humanplymovement>0)
        {
            //if(LightningCastKeywrd.Where(x=> Cast_SpellInput.text.Contains(x)).ToArray()[15]=="Golden Lightning"){PSys_Particles.GetLength(3);}
            if (Cast_SpellInput.isActiveAndEnabled) {
                //show text at runtime around body/etc..
            }

            { foreach (string LNG1 in LightningCastKeywrd)
                { if (LNG1.Contains(PlyCastSysAcknowledgedText.text) && (PlyCastSysAcknowledgedText.text == "Golden Lightning")) {
                        PlyPSYSMainMod.startSizeXMultiplier = 1.5f;
                        PlyPSYSMainMod.startSpeedMultiplier = 1.2f;
                    }
                } }
            { foreach (string SP1 in SPeffectKeyword)
                { if (SP1.Contains(PlyCastSysAcknowledgedText.text) && (PlyCastSysAcknowledgedText.text == "Grant")) {
                        PlyPSYSMainMod.startDelay = 0f;
                        PlyPSYSMainMod.startSizeMultiplier = 1.5f;
                        PlyChoosenSys_Particles.startColor = Color.yellow;
                    }
                } }
            { foreach (string LNG2 in LightningCastKeywrd)
                { if (LNG2.Contains(PlyCastSysAcknowledgedText.text) && (PlyCastSysAcknowledgedText.text == "Pierce")) {
                        //
                        PlyPSYSMainMod.startColor = Color.yellow;
                    }
                } }
            { foreach (string LNG3 in LightningCastKeywrd)
                { if (LNG3.Contains(PlyCastSysAcknowledgedText.text) && (PlyCastSysAcknowledgedText.text == "Split")) {
                        PlyPSYSMainMod.startSizeX = 0.01f;
                        PlyChoosenSys_Particles.startColor = Color.yellow;

                    }
                } }

            { foreach (string LNG4 in LightningCastKeywrd)
                { if (LNG4.Contains(PlyCastSysAcknowledgedText.text) && (PlyCastSysAcknowledgedText.text == "Thunder")) {

                    }
                } }





        }
    }

    public void ResetTxtforCastProcess() { 
    //Final cast,delay then clear,completed.
    Invoke(PlyCastFinalActivationText.text= "", AutoClearFinalCastTxt);
}
    public void ResetTxtforCastingAct()
    {
        //need to make delay with WorldCastProcessTime
        //CastprocessText.text="";>current:plycastsysaknowledgedtxt.txt,completed.
        Invoke(PlyCastSysAcknowledgedText.text = "", WorldCastProcessTime);
    }

}