using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ObjAlgrebraic_Y_Manipulate : MonoBehaviour {
    public LayerMask AlgebraScaleManipulateLay;
    [SerializeField] Camera PlyCam;
    [SerializeField] InputField AlgebraInput;
    [SerializeField] GameObject TrgtedObjToManipulate;
    [SerializeField] bool IsInputNo;

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
                //pop out input field
                //chck AlgebraInput.text is Input a no? if not execute NotaNoInInput,func.
                if(IsInputNo=true){
                    //execute It with 
                  //  MagicPsysComphendLogic

                }else{
                    NotaNo();


                }

            }


        }
	}
    void NotaNo() {

    }

}