using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

//public class ObjAlgrebraic_Y_Manipulate : NetworkBehaviour { 
public class ObjAlgrebraic_Y_Manipulate : MonoBehaviour {
    public LayerMask AlgebraScaleManipulateLay;
    [SerializeField] Camera PlyCam;
    [SerializeField]private GameObject AlgebraInputPopout;
    [SerializeField]private InputField AlgebraInput;
    [SerializeField]protected GameObject TrgtedObjToManipulate;
    [SerializeField] bool IsInputNo;
    private static bool IsAlgebraInputOut = false;
    public float PlyrMaxCastTimeWCurrentObj;
	void Start () {
        PlyCam =GetComponent<Camera>();
        MagicPsysComphendLogic MagicProcessSrcptOnPly= GetComponent<MagicPsysComphendLogic>();

	}
	
	void Update () {
        
        if(Input.GetMouseButtonDown(1)){
            Ray TrgtObjRay=PlyCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit HitRay;
            if (Physics.Raycast(TrgtObjRay,out HitRay,50f,AlgebraScaleManipulateLay)){
                TrgtedObjToManipulate=HitRay.transform.gameObject;
                ForceEnableAlgebraInput();
                //chck AlgebraInput.text is Input a no? if not execute NotaNoInInput,func.
                if(IsInputNo==true){
                    //execute It with 
                  //  MagicPsysComphendLogic

                }else{
                    NotaNo();


                }
                Invoke("ForceSisabledAlgebraInput",PlyrMaxCastTimeWCurrentObj);
            }


        }
	}
    void NotaNo() {

    }

    private void ForceEnableAlgebraInput()
    {   AlgebraInputPopout.SetActive(true);
        AlgebraInput.Select();
    }

    private void ForceDisabledAlgebraInput()
    { AlgebraInputPopout.SetActive(false);
    }

}