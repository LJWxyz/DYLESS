using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//public class DirectionalLightIntensity : NetworkBehaviour {
public class DirectionalLightIntensity : MonoBehaviour { 
    [SerializeField] GameObject Sunlight=null;
       private float minIntensity = 0.1f;
       private float maxIntensity = 1.12f;   
       private float frequency = 0.00125f;
       private float phase = 0.1f;
    [SerializeField] Transform SunLightPlacement=null;

       void Start () 
       {
        SunLightPlacement = Sunlight.transform;
           }
      
       void Update () 
       {
        SunLightPlacement.Rotate(Time.deltaTime/60, 0, 0);
      
          }
}