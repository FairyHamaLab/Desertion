using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoundObject : MonoBehaviour {
    private Transform bound_tranform = null;
    private Vector3 gap;
	// Use this for initialization
	void Start () {
        //this.GetComponent<Button>().interactable = false;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (bound_tranform != null) this.gameObject.transform.position = FloorMgr.instance.camera.WorldToScreenPoint(bound_tranform.position) +gap;
       
	}

    public void SetBoundTranform(Transform set_bound_tranform)
    {
        this.bound_tranform = set_bound_tranform;
       // this.GetComponent<Button>().interactable = true;
    }
    public void SetGap(Vector2 set)
    {
        gap = set;
    }
}
