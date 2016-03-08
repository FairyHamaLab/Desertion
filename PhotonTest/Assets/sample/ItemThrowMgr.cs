using UnityEngine;
using System.Collections;

public class ItemThrowMgr : MonoBehaviour {

    public static ItemThrowMgr instance = null;
    public DropItemMgr drop_item_mgr;
    public GameObject bind_prefab;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("z"))
        {
            if (drop_item_mgr.alert_trap_number > 0)
            {

            }
        }
	}

    public void Throw()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            GameObject new_trap = (GameObject)Instantiate(bind_prefab);
            new_trap.transform.position = new Vector3(this.transform.position.x, 0f, this.transform.position.z);
            new_trap.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
