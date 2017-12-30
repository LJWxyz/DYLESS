using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections.Generic;
[DisallowMultipleComponent]
[System.Serializable]
public class ToggleEvent : UnityEvent<bool>{}

public class PlayerNetworkScrpt : NetworkBehaviour 
{
    [SyncVar (hook = "OnNameChanged")] public string playerName;
    [SyncVar (hook = "OnColorChanged")] public Color playerColor;

    [SerializeField] ToggleEvent onToggleShared;
    [SerializeField] ToggleEvent onToggleLocal;
    [SerializeField] ToggleEvent onToggleRemote;
    [SerializeField] float respawnTime = 5f;

    static List<PlayerNetworkScrpt> players = new List<PlayerNetworkScrpt> ();

    GameObject SceneCamera;
    NetworkAnimator Anim;

    void Start()
    {
        Anim = GetComponent<NetworkAnimator> ();
        SceneCamera = Camera.main.gameObject;

        EnablePlayer ();
    }

    [ServerCallback]
    void OnEnable()
    {
        if (!players.Contains (this))
            players.Add (this);
    }

    [ServerCallback]
    void OnDisable()
    {
        if (players.Contains (this))
            players.Remove (this);
    }

    void Update()
    {
        if (!isLocalPlayer)
        { return;}
        else { 
        Move();
        //Advance Mov Bool Sys
        if(Input.GetKey(KeyCode.Tab)){Anim.animator.SetBool("Jog",true);}else{Anim.animator.SetBool("Jog",false);}
        //Nor GET InputFunc
        if(Input.GetKeyDown(KeyCode.R)){Anim.animator.SetBool("GetInputR",true);}else{Anim.animator.SetBool("GetInputR",false);}

        StandupFromStomachonFloor();
            }
    }
    

    void Move(){
        Anim.animator.SetFloat("VerticalWalking_z",Input.GetAxis("Vertical"));
        Anim.animator.SetFloat("HorizontalWalking_x",Input.GetAxis("Horizontal"));
        Anim.animator.SetFloat("MouseXMov",Input.GetAxis("Mouse X"));
        Anim.animator.SetFloat("MouseYMov",Input.GetAxis("Mouse Y"));
    }

    void StandupFromStomachonFloor(){
        if(gameObject.transform.localRotation.z>20)
        {Anim.animator.SetBool("StandupFaceonfloor",true);}

    }


  

    void DisablePlayer()
    {
        if (isLocalPlayer) 
        {
         //   PlayerCanvas.canvas.HideReticule ();
            SceneCamera.SetActive (true);
        }

        onToggleShared.Invoke (false);

        if (isLocalPlayer)
            onToggleLocal.Invoke (false);
        else
            onToggleRemote.Invoke (false);
    }

    void EnablePlayer()
    {
        if (isLocalPlayer) 
        {
         //   PlayerCanvas.canvas.Initialize ();
            SceneCamera.SetActive (false);
        }

        onToggleShared.Invoke (true);

        if (isLocalPlayer)
            onToggleLocal.Invoke (true);
        else
            onToggleRemote.Invoke (true);
    }

    public void Die()
    {
        if(isLocalPlayer || playerControllerId == -1)
            Anim.animator.SetTrigger ("Died");

        if (isLocalPlayer) 
        {
          //  PlayerCanvas.canvas.WriteGameStatusText ("You Died!");
        //    PlayerCanvas.canvas.PlayDeathAudio ();
        }

        DisablePlayer ();

        Invoke ("Respawn", respawnTime);
    }

    void Respawn()
    {
        if(isLocalPlayer || playerControllerId == -1)
            Anim.animator.SetTrigger ("Restart");

        if (isLocalPlayer) 
        {
            Transform spawn = NetworkManager.singleton.GetStartPosition ();
            transform.position = spawn.position;
            transform.rotation = spawn.rotation;
        }

        EnablePlayer ();
    }

    void OnNameChanged(string value)
    {
        playerName = value;
        gameObject.name = playerName;
        GetComponentInChildren<Text> (true).text = playerName;
    }

    void OnColorChanged(Color value)
    {
        playerColor = value;
     //  GetComponentInChildren<RendererToggler> ().ChangeColor (playerColor);
    }

    [Server]
    public void Won()
    {
        for (int i = 0; i < players.Count; i++)
     //       players [i].RpcGameOver (netId, name);

        Invoke ("BackToLobby", 5f);
    }

    [ClientRpc]
    void RpcGameOver(NetworkInstanceId networkID, string name)
    {
        DisablePlayer ();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (isLocalPlayer)
        {
           // if (netId == networkID)
        //        PlayerCanvas.canvas.WriteGameStatusText ("You Won!");
        //    else
         //       PlayerCanvas.canvas.WriteGameStatusText ("Game Over!\n" + name + " Won");
        }
    }

    void BackToLobby()
    {
        FindObjectOfType<NetworkLobbyManager> ().SendReturnToLobby ();
    }
}