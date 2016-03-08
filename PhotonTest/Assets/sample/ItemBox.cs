using UnityEngine;
using System.Collections;

public class ItemBox : MonoBehaviour {

    private float time = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime * 150;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + Mathf.Sin(time * (Mathf.PI / 180))/200, this.transform.position.z);
        this.transform.Rotate(0f,5f,0);
        if ((int)(time * (Mathf.PI / 180)) >= 360)
        {
            time = 0;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(this.gameObject);
            //CanvasMgr.instance.ViewItemText(CanvasMgr.Item.BIND);
            //other.GetComponent<BehaviourScript>().bind_trap_number++;
        }
    }
}
