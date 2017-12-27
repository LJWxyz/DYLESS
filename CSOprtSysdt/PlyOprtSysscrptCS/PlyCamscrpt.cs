using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Transform))]
public class PlyCamscrpt : MonoBehaviour {
    [SerializeField]  GameObject Head;
    Vector3 BFHeadPos;
    Vector3 AFHeadPos;
    Vector3 ChginHeadPos;
	
    void Start () {
		}
	
    void Update () {
        //update AFHeadPos & BFHeadPos realtime
        BFHeadPos = AFHeadPos ;
        AFHeadPos =Head.transform.localPosition;
 
        ChginHeadPos=AFHeadPos-=BFHeadPos;

        AFHeadPos +=new Vector3 (0,0,ChginHeadPos.z);
    }

}