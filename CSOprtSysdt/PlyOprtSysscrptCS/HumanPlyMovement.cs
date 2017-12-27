using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
//public class HumanPlyMovement : NetworkBehaviour {
    public class HumanPlyMovement : MonoBehaviour {
    Animator Anim;
    public static bool LockPlyMovInput=false;
    public static bool IsEscMode=false;
    protected static bool IsJogMode = false;

    void Awake(){
        Anim=GetComponent<Animator>(); 
    }
    void Start () {Anim.GetBool("Jog");
        Anim.GetBool("LftShift");
        Anim.GetBool("GetInputR");
        Anim.GetBool("Jump");
		
	}

    void Update()
    {
        // if(isLocalPlayer) , Combine the if naavin
        {
            if (!LockPlyMovInput)
            {
                Move();
                StandupFromStomachonFloor();
                Jump();
                Run();
                ChckCursorlck();
                //Advance Mov Bool Sys      
                //Nor GET InputFunc
                if (Input.GetKey(KeyCode.Tab))
                {if (IsJogMode) { IsJogMode = false; Anim.SetBool("Jog", false);
                    }else { IsJogMode = true; Anim.SetBool("Jog", true); }
                }

                if (Input.GetKeyDown(KeyCode.R)){
                    Anim.SetBool("GetInputR", true);
                 }else { Anim.SetBool("GetInputR", false); }
             
                }else { ChckCursorlck(); }
            
        }
    }

    void Move()
        {
            Anim.SetFloat("VerticalWalking_z", Input.GetAxis("Vertical"));
            Anim.SetFloat("HorizontalWalking_x", Input.GetAxis("Horizontal"));
            Anim.SetFloat("MouseXMov", Input.GetAxis("Mouse X"));
            Anim.SetFloat("MouseYMov", Input.GetAxis("Mouse Y"));
        }

    void Run() {
            Anim.SetFloat("LftShift", Input.GetAxis("LeftShift"));
        }

    void Jump(){
        if(Input.GetKey(KeyCode.Space)){Anim.SetBool("Jump",true);}else{Anim.SetBool("Jump",false);}
    }
        
    void StandupFromStomachonFloor(){
        if(gameObject.transform.localRotation.z>20)
        {Anim.SetBool("StandupFaceonfloor",true);}
    }

    void ChckCursorlck(){
        //ChckANDLockCursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {if(IsEscMode)
            {IsEscMode=false;
             LockPlyMovInput=false;
                Cursor.lockState=CursorLockMode.Locked;
                Cursor.visible=false;}else
            {
            IsEscMode=true;
            LockPlyMovInput=true;
            Cursor.lockState =CursorLockMode.Confined;
            Cursor.visible=true;}
    }
        //IngameVerystartSetCursorStatement
        if(!IsEscMode){
            Cursor.lockState=CursorLockMode.Locked;
            Cursor.visible=false;
        }

    }
        
}