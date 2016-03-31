using UnityEngine;
using System.Collections;

public class ItemBox : MonoBehaviour {

    private float time = 0;
    public int my_number = 0;
    public GameObject alert_prefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Desertion/First"))
        {
            if (my_number == 0)
            {
                Destroy(this.gameObject);
                CanvasMgr.instance.ViewItemText(CanvasMgr.Item.BIND);
                other.GetComponent<Desertion>().bind_trap_number++;
            } 
            else if(other.GetComponent<Desertion>().alert_number == 0)
            {
                Destroy(this.gameObject);
                CanvasMgr.instance.ViewItemText(CanvasMgr.Item.ALERT);
                other.GetComponent<Desertion>().bind_trap_number++;
                GameObject new_trap = (GameObject)Instantiate(alert_prefab);
                new_trap.transform.SetParent(other.transform.root);
                new_trap.transform.position = other.transform.root.position;
                new_trap.SetActive(true);
            }
        }
    }
}
