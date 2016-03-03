using UnityEngine;
using System.Collections;

public class DesertionOperator : MonoBehaviour
{

    public Animator animator;//アニメータ

    public bool trap_key = true;//トラップ配置動作制御
    private Transform my_camera_potision;
    private GameObject me;
    private Desertion desertion;
    // Use this for initialization
    void Start()
    {
        //    animator = this.transform.GetChild(0).GetChild(0).GetComponent<Animator>();
        FloorMgr.instance.camera.transform.SetParent(this.transform);
        this.GetComponent<Desertion>().my_camera = FloorMgr.instance.camera;
        my_camera_potision = this.GetComponent<Desertion>().my_camera.transform;
        me = this.transform.parent.gameObject;
        desertion = this.GetComponent<Desertion>();
        animator = this.transform.parent.GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        DropItem();
    }

    private void Move()
    {
        if (desertion.can_move)
        {
            
            if (Input.GetKey("up"))
            {
                animator.SetBool("running", true);
            }

            else if (Input.GetKey("down"))
            {
                animator.SetBool("walking", true);
            }
            else
            {
                animator.SetBool("running", false);
                animator.SetBool("walking", false);
            }


            if (Input.GetKey("right"))
            {
                me.transform.Rotate(0, 5, 0);
            }
            if (Input.GetKey("left"))
            {
                me.transform.Rotate(0, -5, 0);
            }
 
        }


        if (animator.GetBool("running"))
        {
            me.transform.position += me.transform.forward * 0.05f;
        }
        if (animator.GetBool("walking"))
        {
            me.transform.position -= me.transform.forward * 0.025f;
        }

    }
    private void DropItem()
    {
        //トラップを投げる動作
        /*
        if (Input.GetKeyDown("z") && me.trap_number != 0)
        {
            Transform new_trap = (Transform)Instantiate(Trap);
            new_trap.transform.position = this.transform.position;
            new_trap.transform.position += my_camera_potision.forward + new Vector3(0f, 0.75f, 0f);
            new_trap.gameObject.GetComponent<Rigidbody>().useGravity = true;
            new_trap.gameObject.SetActive(true);

            //単位ベクトルの50倍の力+放物線っぽく
            new_trap.gameObject.GetComponent<Rigidbody>().AddForce(my_camera_potision.forward * 50 + new Vector3(0f, 100f, 0f));

            me.trap_number--;
        }
         * */

    }

}
