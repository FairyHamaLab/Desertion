using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

    public  EdgeMgr my_mgr;
    public int number;

    void OnTriggerEnter(Collider other)
    {
        my_mgr.Trigger(number);
    }

    void OnTriggerExit(Collider other)
    {
        my_mgr.disTrigger();
        Debug.Log("my_mgr.disTrigger()");
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
