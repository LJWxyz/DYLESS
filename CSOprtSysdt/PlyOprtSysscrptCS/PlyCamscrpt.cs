using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Transform))]
//public class PlyCamscrpt : NetworkBehaviour { 
public class PlyCamscrpt : MonoBehaviour {
    [SerializeField]  GameObject Head=null;
    Vector3 BFHeadPos;
    Vector3 AFHeadPos;
    Vector3 ChginHeadPos;
	
    void Start () {
		}
	
    void Update () {
//if(isLocalPlayer)   
        //update AFHeadPos & BFHeadPos realtime
        BFHeadPos = AFHeadPos ;
        AFHeadPos =Head.transform.localPosition;
 
        ChginHeadPos=AFHeadPos-=BFHeadPos;

        AFHeadPos +=new Vector3 (0,0,ChginHeadPos.z);
    }

}