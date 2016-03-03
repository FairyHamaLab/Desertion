using UnityEngine;
using System.Collections;

public class testes : MonoBehaviour {

	// Use this for initialization
    public Transform target;
	void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;

        Ray ray = new Ray(transform.position, target.transform.position- transform.position);
        Debug.DrawRay(transform.position, target.transform.position - transform.position, Color.red, 10000.0f);
        if (Physics.Raycast(ray,out hit,100000.0f))
        {

            print("前方に見える");

        }
        else
        {
            Debug.Log("aaaaaaaa");
        }
	}
}
