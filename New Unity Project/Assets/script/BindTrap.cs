using UnityEngine;
using System.Collections;

public class BindTrap : MonoBehaviour {

    public int my_number;
    private Collider target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Hunter"))
        {
            target = other;
            Bind();
            Invoke("Release", 3.0f);
        }
    }

    public void Bind()
    {
        target.GetComponent<BehaviourScript>().can_move = false;       
    }

    public void Release()
    {
        target.GetComponent<BehaviourScript>().can_move = true;
    }

}
