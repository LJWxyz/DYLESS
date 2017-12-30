using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

//public class MenuCanvasFunc: NetworkBehaviour {
    public class MenuCanvasFunc: MonoBehaviour {
    public static bool IsMenuOn= false;
    [SerializeField] GameObject FreakingMenuUI=null;
	void Start () {
		
	}
	
	void Update () {
       // if(isLocalPlayer)
        {if(Input.GetKeyDown(KeyCode.Escape)){
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
        HumanPlyMovement.LockPlyMovInput = false;
    }
    public  void ComeMenuPopout(){
        FreakingMenuUI.SetActive(true);
        IsMenuOn=true;
        HumanPlyMovement.LockPlyMovInput= true;
    }

    public  void FQuitGame(){
        Application.Quit();
    }

}