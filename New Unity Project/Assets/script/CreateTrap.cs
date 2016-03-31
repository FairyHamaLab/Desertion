using UnityEngine;
using System.Collections;

public class CreateTrap : MonoBehaviour {

    private Vector3 set_posi;
    public GameObject bind_trap;
    // Use this for initialization

    void Awake() { }
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (this.GetComponent<Rigidbody>().velocity == new Vector3(0, 0, 0))
        {
            GameObject new_trap = (GameObject)Instantiate(bind_trap);
            new_trap.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            new_trap.SetActive(true);
            Destroy(this.gameObject);
        }
	}
}
