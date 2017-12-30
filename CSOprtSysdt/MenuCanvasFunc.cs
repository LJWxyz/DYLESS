using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

//public class MenuCanvasFunc: NetworkBehaviour {
    public class MenuCanvasFunc: MonoBehaviour {
    public static bool IsMenuOn= false;
    [SerializeField] GameObject FreakingMenuUI;
	void Start () {
		
	}
	
	void Update () {
       // if(isLocalPlayer)
        {if(Input.GetKeyDown(KeyCode.M)){
                if(IsMenuOn)
                { IamFineContinue(); }
                else
                {ComeMenuPopout();}
        }   
        }
		
    }
    public void IamFineContinue(){
        FreakingMenuUI.SetActive(false);
        IsMenuOn=false;
    }
    public  void ComeMenuPopout(){
        FreakingMenuUI.SetActive(true);
        IsMenuOn=true;
    }

    public  void FQuitGame(){
        Application.Quit();
    }

}