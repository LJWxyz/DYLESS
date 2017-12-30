using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

[DisallowMultipleComponent]
//public class RobotKyleNavUpdate: NetworkBehaviour{
public class RobotKyleNavUpdate : MonoBehaviour {
    [SerializeField] NavMeshAgent NavMeshonRobot;

    void Start () {
        NavMeshAgent NavMeshonRobot= GetComponent<NavMeshAgent>();
	}

	void Update () {
        StartCoroutine("UpdatePointtoWalkTo",12.213f);
	}
    IEnumerator  UpdatePointtoWalkTo(){
        Vector3 PointRobotWalkto =new Vector3(Random.Range(70948,77952),0,Random.Range(80713.1f,85042));
        NavMeshonRobot.SetDestination(PointRobotWalkto);
        return null;
    }
}