using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//public class LampOnOffLogicscpt: NetworkBehaviour { 
public class LampOnOffLogicscpt : MonoBehaviour {
   [SerializeField] Light Sun;
  [SerializeField]  Transform SunTransform=null ;
    [SerializeField] GameObject TheLightBulb;
    void Start () {
        TheLightBulb = gameObject;
	}
	
    //on server,not clients stuff

	void Update () {
        if(SunTransform.rotation.x>180){
            TheLightBulb.SetActive(true);
        }else
        {
            TheLightBulb.SetActive(false);
        }
	}

}
