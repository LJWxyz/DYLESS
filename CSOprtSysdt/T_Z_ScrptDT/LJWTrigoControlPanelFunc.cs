using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//public class LJWTrigoControlPanelFunc : NetworkBehaviour {
    public class LJWTrigoControlPanelFunc :MonoBehaviour {
    [SerializeField] GameObject BackgroundonTrigoPanel ;
    protected bool IsBackgroundJetBlack= false;
    [SerializeField] Transform MaterialSpwnpoint;
    [SerializeField] Vector3 Lulubakka;

    void Start () {
       
	}

	void Update () {
       
    }

    public void PressedonChgBackground(){
        if(IsBackgroundJetBlack){
            BackgroundonTrigoPanel.SetActive(false);
            IsBackgroundJetBlack=false;
        }else{
            BackgroundonTrigoPanel.SetActive(true);
            IsBackgroundJetBlack=true;
        }

    }

    public void SpwnRedLine1m0101(){
        GameObject LJWtrigoRedline1m0101 = Instantiate(Resources.Load("LJWTrigo1m_0.1_0.1RedLine", typeof(GameObject))) as GameObject;
        LJWtrigoRedline1m0101.transform.SetPositionAndRotation(Lulubakka, MaterialSpwnpoint.rotation);
    }

}