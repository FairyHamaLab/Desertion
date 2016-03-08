using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DropItemMgr : MonoBehaviour {

    public static DropItemMgr instance = null;
    public GameObject itembox_prefab;

    public int bind_trap_number = 0;
    public int alert_trap_number = 0;

    void Awake()
    {
        if(instance == null)
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
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Trap/Bind"))
        {
            bind_trap_number++;
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Trap/Alert"))
        {
            alert_trap_number++;
        }
    }

}
