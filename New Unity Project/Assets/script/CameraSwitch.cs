using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {

    private bool tri;
    private string c_n;
    private Transform c_right, c_left;
    private GameObject player;
    private Vector3 side_posx = new Vector3(0.35f, 0f, 0f);
    private Vector3 side_posz = new Vector3(0f, 0f, 0.35f);
    private Vector3 pos_a,pos_b,pos_c,pos_d;
    // Use this for initialization
	void Start (){
        pos_a = transform.root.FindChild("Camera_a").GetComponent<Transform>().position;
        pos_b = transform.root.FindChild("Camera_b").GetComponent<Transform>().position;
        pos_c = transform.root.FindChild("Camera_c").GetComponent<Transform>().position;
        pos_d = transform.root.FindChild("Camera_d").GetComponent<Transform>().position;
    }
	
	// Update is called once per frame
    void Update()
    {
        if (tri)
        {
            if (Input.GetKey("a"))
            {
                if (c_n == "Camera_a")
                {

                    transform.root.FindChild("Camera_c").GetComponent<Transform>().position = pos_c + side_posz;
                    transform.root.FindChild("Camera_c").GetComponent<Camera>().rect = new Rect(0.15f, 0.23f, 0.3f, 0.5f);
                    transform.root.FindChild("Camera_c").GetComponent<Camera>().enabled = true;
                }
                else if (c_n == "Camera_b")
                {
                    transform.root.FindChild("Camera_d").GetComponent<Transform>().position = pos_d - side_posz;
                    transform.root.FindChild("Camera_d").GetComponent<Camera>().rect = new Rect(0.15f, 0.23f, 0.3f, 0.5f);
                    transform.root.FindChild("Camera_d").GetComponent<Camera>().enabled = true;
                }
                else if (c_n == "Camera_c")
                {
                    transform.root.FindChild("Camera_b").GetComponent<Transform>().position = pos_b + side_posx;
                    transform.root.FindChild("Camera_b").GetComponent<Camera>().rect = new Rect(0.15f, 0.23f, 0.3f, 0.5f);
                    transform.root.FindChild("Camera_b").GetComponent<Camera>().enabled = true;
                }
                else if (c_n == "Camera_d")
                {
                    transform.root.FindChild("Camera_a").GetComponent<Transform>().position = pos_a - side_posx;
                    transform.root.FindChild("Camera_a").GetComponent<Camera>().rect = new Rect(0.15f, 0.23f, 0.3f, 0.5f);
                    transform.root.FindChild("Camera_a").GetComponent<Camera>().enabled = true;
                }
                player.GetComponent<BehaviourScript>().can_move = false;
            }
            else if (Input.GetKey("d"))
            {
                if (c_n == "Camera_a")
                {
                    transform.root.FindChild("Camera_d").GetComponent<Transform>().position = pos_d + side_posz;
                    transform.root.FindChild("Camera_d").GetComponent<Camera>().rect = new Rect(0.55f, 0.23f, 0.3f, 0.5f);
                    transform.root.FindChild("Camera_d").GetComponent<Camera>().enabled = true;
                }
                else if (c_n == "Camera_b")
                {
                    transform.root.FindChild("Camera_c").GetComponent<Transform>().position = pos_c - side_posz;
                    transform.root.FindChild("Camera_c").GetComponent<Camera>().rect = new Rect(0.55f, 0.23f, 0.3f, 0.5f);
                    transform.root.FindChild("Camera_c").GetComponent<Camera>().enabled = true;
                }
                else if (c_n == "Camera_c")
                {
                    transform.root.FindChild("Camera_a").GetComponent<Transform>().position = pos_a + side_posx;
                    transform.root.FindChild("Camera_a").GetComponent<Camera>().rect = new Rect(0.55f, 0.23f, 0.3f, 0.5f);
                    transform.root.FindChild("Camera_a").GetComponent<Camera>().enabled = true;
                }
                else if (c_n == "Camera_d")
                {
                    transform.root.FindChild("Camera_b").GetComponent<Transform>().position = pos_b - side_posx;
                    transform.root.FindChild("Camera_b").GetComponent<Camera>().rect = new Rect(0.55f, 0.23f, 0.3f, 0.5f);
                    transform.root.FindChild("Camera_b").GetComponent<Camera>().enabled = true;
                }
                player.GetComponent<BehaviourScript>().can_move = false;
            }
            else
            {
                this.transform.root.FindChild("Camera_a").GetComponent<Camera>().enabled = false;
                this.transform.root.FindChild("Camera_b").GetComponent<Camera>().enabled = false;
                this.transform.root.FindChild("Camera_c").GetComponent<Camera>().enabled = false;
                this.transform.root.FindChild("Camera_d").GetComponent<Camera>().enabled = false;
                player.GetComponent<BehaviourScript>().can_move = true;
            }
        }
    }

    public void Trigger(bool t)
    {
        tri = t;
    }

    public void getName(string n)
    {
        c_n = n;
    }

    public bool getEnable(string n)
    {
        if (n == "right")
        {
            if (c_n == "Camera_a")
            {
                return transform.root.FindChild("Camera_d").gameObject.activeSelf;
            }
            else if (c_n == "Camera_b")
            {
                return transform.root.FindChild("Camera_c").gameObject.activeSelf;
            }
            else if (c_n == "Camera_c")
            {
                return transform.root.FindChild("Camera_a").gameObject.activeSelf;
            }
            else
            {
                return transform.root.FindChild("Camera_b").gameObject.activeSelf;
            }
        }
        else
        {
            if (c_n == "Camera_a")
            {
                return transform.root.FindChild("Camera_c").gameObject.activeSelf;
            }
            else if (c_n == "Camera_b")
            {
                return transform.root.FindChild("Camera_d").gameObject.activeSelf;
            }
            else if (c_n == "Camera_c")
            {
                return transform.root.FindChild("Camera_b").gameObject.activeSelf;
            }
            else
            {
                return transform.root.FindChild("Camera_a").gameObject.activeSelf;
            } 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        player = other.gameObject;
    }
}

