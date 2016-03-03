using UnityEngine;
using System.Collections;

public class SizeRe : MonoBehaviour {
    private bool resize = false;
    private float size;
    static public ScrollController sc = null;
	// Use this for initialization
	void Start () {
        size = this.GetComponent<RectTransform>().sizeDelta.y;
	}
	
	// Update is called once per frame
	void Update () {
        if(!resize&&size != this.GetComponent<RectTransform>().sizeDelta.y)
        {
            resize = true;
            if (sc != null) sc.AddTotal(this.GetComponent<RectTransform>().sizeDelta.y);
        }
        
        
	}
}
