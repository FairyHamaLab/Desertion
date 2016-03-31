using UnityEngine;
using System.Collections;

public class buttonMgr : MonoBehaviour {

    public string input_text_administrator,input_text_signer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ButtonPush( )
    {
        Debug.Log("Button Push !!");
        CanvasMgr.instance.miss.SetActive(false);
        DeviceMgr.instance.check = true;
    }
}
