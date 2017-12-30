using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//public class LJWTrigoControlPanelFunc : NetworkBehaviour {
    public class LJWTrigoControlPanelFunc :MonoBehaviour {
    [SerializeField] GameObject BackgroundonTrigoPanel=null ;
    protected bool IsBackgroundJetBlack= false;
    [SerializeField] Transform MaterialSpwnpoint=null;
    [SerializeField] Vector3 Lulubakka;
    [SerializeField] bool IsXYaxisshown = false;
    [SerializeField] GameObject Xaxisobj=null;
    [SerializeField] GameObject Yaxisobj=null;

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

    public void ToggleXYaxis() {
        if (IsXYaxisshown)
        {
            IsXYaxisshown = false;
            Xaxisobj.SetActive(false);
            Yaxisobj.SetActive(false);
        }else {
            Xaxisobj.SetActive(true);
            Yaxisobj.SetActive(true);
            IsXYaxisshown = true;
        }

    }

}