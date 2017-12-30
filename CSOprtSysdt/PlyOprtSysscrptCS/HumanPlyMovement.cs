using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
//public class HumanPlyMovement : NetworkBehaviour {
    public class HumanPlyMovement : MonoBehaviour {
    Animator Anim;
    [SerializeField] public static bool LockPlyMovInput=false;
    public static bool IsLockMousecursor=true;
    protected static bool IsJogMode = false;
    [SerializeField]private StatManagement PlyrHealth;
    [SerializeField]private StatManagement PlyrManipulationPower;
    [SerializeField]private StatManagement PlyrStamina;
    protected float PlyrMaxCastTimeNor;
    private bool IsAdult=false;
    private bool HaveAnemia;
    private int PlyrForm=1;
    public float plyrmapow;

  private  void Awake(){
        Anim=GetComponent<Animator>();
    //    HealthStartSet();
      //  ManipulationPowerStrtSet();
       
        
    }
  protected void Start () {
        Anim.GetBool("Jog");
        Anim.GetFloat("LftShift");
        Anim.GetBool("GetInputR");
        Anim.GetBool("Jump");
       // PlyrHealth.UpdateDefaultVal();
       // PlyrManipulationPower.UpdateDefaultVal();
       //PlyrStamina.UpdateDefaultVal();
        //SetPlyrMaxCastTimeNor();
    }

   protected void Update()
    {
        // if(isLocalPlayer) , Combine the if naavin
            if (!LockPlyMovInput)
            {
                AcesDTVar();
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
                //lock cursor when start game,and during game
                if (IsLockMousecursor)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                }
              
        }
            else { ChckCursorlck(); AcesDTVar(); }
            
        
    }

  private  void Move()
        {
            Anim.SetFloat("VerticalWalking_z", Input.GetAxis("Vertical"));
            Anim.SetFloat("HorizontalWalking_x", Input.GetAxis("Horizontal"));
            Anim.SetFloat("MouseXMov", Input.GetAxis("Mouse X"));
            Anim.SetFloat("MouseYMov", Input.GetAxis("Mouse Y"));
        }

 private   void Run() {
            Anim.SetFloat("LftShift", Input.GetAxis("LeftShift"));
        }

  private  void Jump(){
        if(Input.GetKey(KeyCode.Space)){Anim.SetBool("Jump",true);}else{Anim.SetBool("Jump",false);}
    }
        
  private  void StandupFromStomachonFloor(){
        if(gameObject.transform.localRotation.z>20)
        {Anim.SetBool("StandupFaceonfloor",true);}
    }

   private void ChckCursorlck(){
        //ChckANDLockCursor
        if (Input.GetKeyDown(KeyCode.Slash))
        {if(!IsLockMousecursor)
            {IsLockMousecursor=true;
             LockPlyMovInput=false;
                Cursor.lockState=CursorLockMode.Locked;
                Cursor.visible=false;} else
            {
            IsLockMousecursor=false;
            LockPlyMovInput=true;
                Cursor.lockState = CursorLockMode.None;
            Cursor.visible=true;}
            //if (IsLockMousecursor) { Cursor.lockState = CursorLockMode.Locked; }
    } 
    }

    private void OnCollisionEnter(Collision WholeBodyColl)
    {
         {
        }
        
    }
    private void HealthStartSet() {
        if (IsAdult) { PlyrHealth.BaseMaxValueResolve = 110f;
            PlyrHealth.CurrentValueResolve = 110f;
            if (HaveAnemia) {
                PlyrHealth.BaseMaxValueResolve = 105f;
                PlyrHealth.CurrentValueResolve = 105f;}

        }
        else
        {
            PlyrHealth.BaseMaxValueResolve = 100f;
            PlyrHealth.CurrentValueResolve = 100f;
        }
    }
  
    private void ManipulationPowerStrtSet()
    {if (PlyrForm.Equals(1)) { PlyrManipulationPower.BaseMaxValueResolve = 100f;PlyrManipulationPower.CurrentValueResolve = 100f; }
        else { if (PlyrForm.Equals(2)) { PlyrManipulationPower.BaseMaxValueResolve = 110f; PlyrManipulationPower.CurrentValueResolve = 110f; }
            if (PlyrForm.Equals(3)) { PlyrManipulationPower.BaseMaxValueResolve = 125f; PlyrManipulationPower.CurrentValueResolve = 125f; }
            if(PlyrForm.Equals(4)) { PlyrManipulationPower.BaseMaxValueResolve = 150f; PlyrManipulationPower.CurrentValueResolve = 150f; }
            if (PlyrForm.Equals(5)) { PlyrManipulationPower.BaseMaxValueResolve = 160f; PlyrManipulationPower.CurrentValueResolve = 160f; }
            if (PlyrForm.Equals(6)) { PlyrManipulationPower.BaseMaxValueResolve = 175f; PlyrManipulationPower.CurrentValueResolve = 175f; }
        }
    }

    private void SetPlyrMaxCastTimeNor()
    {if (PlyrForm.Equals(1)) { PlyrMaxCastTimeNor = 10.123f; }
        else
        {   if (PlyrForm.Equals(2)) { PlyrMaxCastTimeNor = 13.432f; }
            if (PlyrForm.Equals(3)) { PlyrMaxCastTimeNor = 15.412f; }
            if (PlyrForm.Equals(4)) { PlyrMaxCastTimeNor = 17.521f; }
            if (PlyrForm.Equals(5)) { PlyrMaxCastTimeNor = 19.523f; }
            if (PlyrForm.Equals(6)) { PlyrMaxCastTimeNor = 21.2532f; }
        }
    }

    public void AcesDTVar()
    {plyrmapow = PlyrManipulationPower.BaseMaxValueResolve;}

}